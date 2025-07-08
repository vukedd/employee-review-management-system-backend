using Domain.Enums.Evaluation;
using Presentation.Contracts.Request.Response;
using Presentation.Contracts.Response.User;

namespace Presentation.Contracts.Response.ConcreteEvaluation
{
    public class GetPendingEvaluationByIdResponse
    {
        public long Id { get; set; }
        public IEnumerable<ResponseDto> Responses { get; set; } = new List<ResponseDto>();
        public UserDto? Reviewee { get; set; }
        public UserDto? Reviewer { get; set; }
        public EvaluationType Type { get; set; }
        public DateOnly? Deadline { get; set; }

    }
}
