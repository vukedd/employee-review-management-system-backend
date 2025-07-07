using Domain.Enums.Response;

namespace Presentation.Contracts.Request.Response
{
    public class ResponseDto
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public ResponseType Type { get; set; }
        public string Question { get; set; }
    }
}
