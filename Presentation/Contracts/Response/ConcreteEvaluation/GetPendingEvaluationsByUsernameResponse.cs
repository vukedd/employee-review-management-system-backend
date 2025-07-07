using Domain.Enums.Evaluation;
using Presentation.Contracts.Response.User;

namespace Presentation.Contracts.Response.ConcreteEvaluation
{
    public class GetPendingEvaluationsByUsernameResponse
    {
        public long Id { get; set; }
        public EvaluationType EvaluationType { get; set; }
        public UserDto? Reviewee { get; set; }
        public DateOnly? Deadline { get; set; }
    }
}
