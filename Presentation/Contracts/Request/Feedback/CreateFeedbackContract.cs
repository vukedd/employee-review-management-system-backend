using Domain.Enums.Feedback;

namespace Presentation.Contracts.Request.Feedback
{
    public class CreateFeedbackContract
    {
        public string Content { get; set; } = string.Empty;
        public Visibility Visibility { get; set; }
        public long ReviewerId { get; set;}
        public long RevieweeId { get; set;}
    }
}
