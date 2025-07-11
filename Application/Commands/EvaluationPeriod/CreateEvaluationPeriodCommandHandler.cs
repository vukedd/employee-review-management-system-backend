using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Common.Services;
using Application.Mappers.Evaluations;
using Domain.Models.Evaluations;
using Domain.Models.Evaluations.EvaluationComponents;
using Domain.Models.Memberships;
using MediatR;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Application.Commands.EvaluationPeriod
{
    public class CreateEvaluationPeriodCommandHandler : IRequestHandler<CreateEvaluationPeriodCommand, Domain.Models.Evaluations.EvaluationPeriod>
    {
        private readonly IEvaluationPeriodRepository _evaluationPeriodRepository;
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IConcreteEvaluationRepository _concreteEvaluationRepository;
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMailService _mailService;

        public CreateEvaluationPeriodCommandHandler(
            IEvaluationPeriodRepository evaluationPeriodRepository, 
            IEvaluationRepository evaluationRepository,
            ITeamRepository teamRepository,
            IConcreteEvaluationRepository concreteEvaluationRepository,
            IMembershipRepository membershipRepository,
            IMailService mailService)
        {
            _concreteEvaluationRepository = concreteEvaluationRepository;
            _evaluationPeriodRepository = evaluationPeriodRepository;
            _evaluationRepository = evaluationRepository;
            _teamRepository = teamRepository;
            _membershipRepository = membershipRepository;
            _mailService = mailService;
        }

        public async Task<Domain.Models.Evaluations.EvaluationPeriod> Handle(CreateEvaluationPeriodCommand request, CancellationToken cancellationToken)
        {
            var newEvaluationPeriod = new Domain.Models.Evaluations.EvaluationPeriod
            {
                Name = request.Name,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };


            #region evaluation period creation + mapping eval. periods with evals.
            foreach (long id in request.EvaluationIds)
            {
                var evaluation = await _evaluationRepository.GetEvaluationByIdAsync(id);

                if (evaluation == null)
                    throw new NotFoundException($"The evaluation with the id {id} could not be found!");

                newEvaluationPeriod.EvaluationPeriodEvaluations.Add(new EvaluationPeriodEvaluation
                {
                    EvaluationId = id,
                });
            }

            newEvaluationPeriod = await _evaluationPeriodRepository.CreateEvaluationPeriodAsync(newEvaluationPeriod);

            #endregion

            #region loading all evaluations which have to be filled
            var evaluations = new List<Domain.Models.Evaluations.Evaluation>();
            foreach (var el in newEvaluationPeriod.EvaluationPeriodEvaluations)
            {
                var currEvaluation = await _evaluationRepository.GetEvaluationByIdAsync(el.Evaluation.Id);
                if (currEvaluation != null)
                    evaluations.Add(currEvaluation);
            }

            #endregion

            var teams = await _teamRepository.GetAllTeams();

            var concreteEvaluationsCopies = new List<Domain.Models.Evaluations.ConcreteEvaluation>();
            foreach (var eval in evaluations)
            {
                switch (eval.Type)
                {
                    case Domain.Enums.Evaluation.EvaluationType.SELF:
                        concreteEvaluationsCopies.AddRange(GenerateSelfEvaluations(teams, eval, newEvaluationPeriod));
                        break;
                    case Domain.Enums.Evaluation.EvaluationType.PEER:
                        concreteEvaluationsCopies.AddRange(GeneratePeerEvaluations(teams, eval, newEvaluationPeriod));
                        break;
                    case Domain.Enums.Evaluation.EvaluationType.LEAD:
                        concreteEvaluationsCopies.AddRange(GenerateLeadEvaluations(teams, eval, newEvaluationPeriod));
                        break;
                }
            }

            await _concreteEvaluationRepository.CreateConcreteEvaluationRange(concreteEvaluationsCopies);

            #region fetch users and send emails that a new cycle has begun
            HashSet<Domain.Models.Users.User> mailingList = new HashSet<Domain.Models.Users.User>();

            var memberships = await _membershipRepository.GetAllMemberships();
            foreach (var membership in memberships)
            {
                if (!mailingList.Contains(membership.User))
                {
                    mailingList.Add(membership.User);
                }
            }

            foreach (var user in mailingList) 
            {
                try
                {
                    await _mailService.EvaluationCycleEmail(user.Email, newEvaluationPeriod.Name, newEvaluationPeriod.StartDate, newEvaluationPeriod.EndDate);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"E-mail address {user.Email} couldn't be found!");
                }
            }
            #endregion
            return newEvaluationPeriod;
        }

        private List<Domain.Models.Evaluations.ConcreteEvaluation> GenerateSelfEvaluations(IEnumerable<Domain.Models.Memberships.Team> teams, Domain.Models.Evaluations.Evaluation eval, Domain.Models.Evaluations.EvaluationPeriod evalPeriod)
        {
            List<Domain.Models.Evaluations.ConcreteEvaluation> resultList = new List<Domain.Models.Evaluations.ConcreteEvaluation>();

            foreach (var team in teams)
            {
                foreach (var membership1 in team.Memberships)
                {
                    Domain.Models.Evaluations.ConcreteEvaluation newEvaluation = new Domain.Models.Evaluations.ConcreteEvaluation
                    {
                        Pending = true,
                        Team = team,
                        Evaluation = eval,
                        Reviewer = membership1.User,
                        Reviewee = membership1.User,
                        EvaluationPeriod = evalPeriod
                        
                    };

                    newEvaluation.Responses = GenerateResponses(eval.Questions);
                    resultList.Add(newEvaluation);
                }
            }

            return resultList;
        }
        private List<Domain.Models.Evaluations.ConcreteEvaluation> GenerateLeadEvaluations(IEnumerable<Domain.Models.Memberships.Team> teams, Domain.Models.Evaluations.Evaluation eval, Domain.Models.Evaluations.EvaluationPeriod evalPeriod)
        {
            List<Domain.Models.Evaluations.ConcreteEvaluation> resultList = new List<Domain.Models.Evaluations.ConcreteEvaluation>();
            foreach (var team in teams)
            {
                foreach (var membership1 in team.Memberships)
                {
                    if (!membership1.IsTeamLead)
                        continue;

                    foreach (var membership2 in team.Memberships)
                    {
                        if (membership1.UserId == membership2.UserId)
                            continue;

                        Domain.Models.Evaluations.ConcreteEvaluation newEvaluation = new Domain.Models.Evaluations.ConcreteEvaluation
                        {
                            Pending = true,
                            Team = team,
                            Evaluation = eval,
                            Reviewer = membership1.User,
                            Reviewee = membership2.User,
                            EvaluationPeriod = evalPeriod
                        };

                        newEvaluation.Responses = GenerateResponses(eval.Questions);
                        resultList.Add(newEvaluation);
                    }
                }
            }

            return resultList;
        }
        private List<Domain.Models.Evaluations.ConcreteEvaluation> GeneratePeerEvaluations(IEnumerable<Domain.Models.Memberships.Team> teams, Domain.Models.Evaluations.Evaluation eval, Domain.Models.Evaluations.EvaluationPeriod evalPeriod)
        {
            List<Domain.Models.Evaluations.ConcreteEvaluation> resultList = new List<Domain.Models.Evaluations.ConcreteEvaluation>();
            foreach (var team in teams)
            {
                foreach (var membership1 in team.Memberships)
                {
                    if (membership1.IsTeamLead)
                    {
                        continue;
                    }

                    foreach (var membership2 in team.Memberships)
                    {
                        if (membership1.UserId == membership2.UserId)
                            continue;

                        if (membership2.IsTeamLead)
                            continue;

                        Domain.Models.Evaluations.ConcreteEvaluation newEvaluation = new Domain.Models.Evaluations.ConcreteEvaluation
                        {
                            Pending = true,
                            Team = team,
                            Evaluation = eval,
                            Reviewer = membership1.User,
                            Reviewee = membership2.User,
                            EvaluationPeriod = evalPeriod
                        };

                        newEvaluation.Responses = GenerateResponses(eval.Questions);
                        resultList.Add(newEvaluation);
                    }
                }
            }

            return resultList;
        }
    
        private List<Domain.Models.Evaluations.EvaluationComponents.Response> GenerateResponses(IEnumerable<Question> questions)
        {
            List<Response> responses = new List<Response>();
            foreach (var question in questions)
            {
                responses.Add(new Response
                {
                    Type = question.Type == Domain.Enums.Question.QuestionType.SCALAR
                        ? Domain.Enums.Response.ResponseType.SCALAR
                        : Domain.Enums.Response.ResponseType.TEXT,

                    QuestionId = question.Id,
                    Content = "",
                });
            }

            return responses;
        }
    
    }
    // We are using records to represent DTOs which because of their immutablity feature, since we don't want to modify
    // the request data while transfering it to the handler.
    public record CreateEvaluationPeriodCommand(DateOnly StartDate, DateOnly EndDate, string Name, string Description, IEnumerable<long> EvaluationIds) : IRequest<Domain.Models.Evaluations.EvaluationPeriod>;

}
