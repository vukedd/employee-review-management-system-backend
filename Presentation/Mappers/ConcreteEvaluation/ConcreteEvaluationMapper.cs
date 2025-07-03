using Application.Queries.ConcreteEvaluation;
using Presentation.Contracts.Request.ConcreteEvaluation;
using Presentation.Contracts.Response.ConcreteEvaluation;
using Presentation.Mappers.Response;
using Presentation.Mappers.User;

namespace Presentation.Mappers.ConcreteEvaluation
{
    public static class ConcreteEvaluationMapper
    {
        #region BY USERNAME
        public static GetPendingEvaluationsQuery ToQuery(this GetPendingEvaluationsByUsernameContract contract)
            => new GetPendingEvaluationsQuery(contract.Username);

        public static GetPendingEvaluationsByUsernameResponse ToResponse(this Domain.Models.Evaluations.ConcreteEvaluation eval)
        {
            return new GetPendingEvaluationsByUsernameResponse
            {
                Id = eval.Id,
                EvaluationType = eval.Evaluation.Type,
                Reviewee = eval.Reviewee.ToUserDto()

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
    }
}
