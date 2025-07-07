using Application.Commands.ConcreteEvaluation;
using Application.Mappers.Evaluations.EvaluationComponents;
using Application.Queries.ConcreteEvaluation;
using Domain.Models.Evaluations;
using Presentation.Contracts.Request.ConcreteEvaluation;
using Presentation.Contracts.Response.ConcreteEvaluation;
using Presentation.Mappers.Response;
using Presentation.Mappers.User;
using System.Runtime.CompilerServices;

namespace Presentation.Mappers.ConcreteEvaluation
{
    public static class ConcreteEvaluationMapper
    {
        #region BY USERNAME
        public static GetPendingEvaluationsQuery ToQuery(this GetPendingEvaluationsByUsernameContract contract)
            => new GetPendingEvaluationsQuery(contract.Username, contract.Filter, contract.TeamId);

        public static GetPendingEvaluationsByUsernameResponse ToResponse(this Domain.Models.Evaluations.ConcreteEvaluation eval)
        {
            return new GetPendingEvaluationsByUsernameResponse
            {
                Id = eval.Id,
                EvaluationType = eval.Evaluation.Type,
                Reviewee = eval.Reviewee.ToUserDto(),
                Deadline = eval.EvaluationPeriod.EndDate
            };
        }
        #endregion

        #region BY ID

        public static GetPendingEvaluationByIdQuery ToQuery(this GetPendingEvaluationByIdContract contract)
            => new GetPendingEvaluationByIdQuery(contract.EvaluationId);


        public static GetPendingEvaluationByIdResponse ToResponseById(this Domain.Models.Evaluations.ConcreteEvaluation evaluation)
        {
            return new GetPendingEvaluationByIdResponse
            {
                Id = evaluation.Id,
                Responses = evaluation.Responses.Select(r => r.ToResponseDto()),
                Reviewee = evaluation.Reviewee.ToUserDto(),
                Reviewer = evaluation.Reviewer.ToUserDto()
            };
        }
        #endregion

        #region SUBMIT

        public static SubmitEvaluationCommand ToCommand(this SubmitEvaluationRequestContract contract)
            => new SubmitEvaluationCommand(contract.Id, contract.Responses.Select(re => re.ToAppResponseDto()).ToList());

        public static SubmitEvaluationResponseContract ToSubmitResponse(this Domain.Models.Evaluations.ConcreteEvaluation evaluation)
        {
            return new SubmitEvaluationResponseContract
            {
                Id = evaluation.Id,
                Responses = evaluation.Responses.Select(r => r.ToResponseDto()),
                Reviewee = evaluation.Reviewee.ToUserDto(),
                Reviewer = evaluation.Reviewer.ToUserDto(),
                SubmissionTimestamp = (DateTime)evaluation.SubmissionTimestamp
            };
        }
        #endregion

        #region EDIT SELF
        public static EditEvaluationCommand ToEditCommand(this EditSelfEvaluationContract contract)
            => new EditEvaluationCommand(contract.Id, contract.Responses.Select(re => re.ToDomainEntity()).ToList());

        public static EditSelfEvaluationResponse ToEditResponse(this Domain.Models.Evaluations.ConcreteEvaluation evaluation)
        {
            return new EditSelfEvaluationResponse
            {
                Id = evaluation.Id,
                Responses = evaluation.Responses.Select(re => re.ToPresResponseDto()).ToList(),
                Reviewee = evaluation.Reviewee.ToUserDto(),
                Reviewer = evaluation.Reviewer.ToUserDto(),
                SubmissionTimestamp = (DateTime)evaluation.SubmissionTimestamp
            };
        }
        #endregion

        #region COUNT
        public static GetPendingEvaluationCountByUsernameQuery ToCountQuery(this GetPendingEvaluationCoundByUsernameRequest request)
            => new GetPendingEvaluationCountByUsernameQuery(request.Username);
        #endregion
    }
}
