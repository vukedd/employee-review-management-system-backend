using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ConcreteEvaluation
{
    public class GetPendingEvaluationsQueryHandler : IRequestHandler<GetPendingEvaluationsQuery, IEnumerable<Domain.Models.Evaluations.ConcreteEvaluation>>
    {
        private readonly IConcreteEvaluationRepository _concreteEvaluationRepository;
        public GetPendingEvaluationsQueryHandler(IConcreteEvaluationRepository concreteEvaluationRepository) 
        {
            _concreteEvaluationRepository = concreteEvaluationRepository;
        }

        public async Task<IEnumerable<Domain.Models.Evaluations.ConcreteEvaluation>> Handle(GetPendingEvaluationsQuery request, CancellationToken cancellationToken)
        {
            var pendingEvaluations = await _concreteEvaluationRepository.GetPendingEvaluationsByUsername(request.Username);
            
            // If there are no pending evaluations return it immeditely to skip unnecessary operations
            if (pendingEvaluations.Count() == 0)
                return pendingEvaluations;

            var validPendingEvaluations = new List<Domain.Models.Evaluations.ConcreteEvaluation>();
            var currDate = DateOnly.FromDateTime(DateTime.Now);
            foreach (var eval in pendingEvaluations)
            {
                foreach (var epe in eval.Evaluation.EvaluationPeriodEvaluations.Select(ep => ep).ToList())
                {
                    if (epe.EvaluationPeriod.EndDate >= currDate)
                    {
                        validPendingEvaluations.Add(eval);
                    }
                }
            }

            return validPendingEvaluations;

        }
    }

    public record GetPendingEvaluationsQuery(string Username) : IRequest<IEnumerable<Domain.Models.Evaluations.ConcreteEvaluation>> { }
}
