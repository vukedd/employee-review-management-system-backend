using Application.Queries.ConcreteEvaluation;
using Presentation.Contracts.Request.ConcreteEvaluation;
using Presentation.Contracts.Response.ConcreteEvaluation;
using Presentation.Mappers.User;

namespace Presentation.Mappers.ConcreteEvaluation
{
    public static class ConcreteEvaluationMapper
    {
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
    }
}
