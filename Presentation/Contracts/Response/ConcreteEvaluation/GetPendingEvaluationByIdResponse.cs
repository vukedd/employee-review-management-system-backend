using Presentation.Contracts.Request;
using Presentation.Contracts.Response.User;

namespace Presentation.Contracts.Response.ConcreteEvaluation
{
    public class GetPendingEvaluationByIdResponse
    {
        public long Id { get; set; }
        public IEnumerable<ResponseDto> Responses { get; set; } = new List<ResponseDto>();
        public UserDto? Reviewee { get; set; }
        public UserDto? Reviewer { get; set; }

    }
}
