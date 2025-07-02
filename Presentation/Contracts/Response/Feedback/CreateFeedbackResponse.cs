using Domain.Enums.Feedback;
using Presentation.Contracts.Response.User;

namespace Presentation.Contracts.Response.Feedback
{
    public class CreateFeedbackResponse
    {
        public string Content { get; set; } = string.Empty;
        public Visibility Visibility { get; set; }
        public UserDto Reviewer { get; set; }
        public UserDto Reviewee { get; set; }
    }
}
