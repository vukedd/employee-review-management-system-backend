using Application.Common.DTOs;
using Presentation.Contracts.Response.User;

namespace Presentation.Contracts.Request.ConcreteEvaluation
{
    public class EditSelfEvaluationContract
    {
        public long Id { get; set; }
        public IEnumerable<ResponseDto> Responses { get; set; } = new List<ResponseDto>();
        public UserDto? Reviewee { get; set; }
        public UserDto? Reviewer { get; set; }
    }
}
