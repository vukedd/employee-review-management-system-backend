using Application.Commands.Feedback;
using Presentation.Contracts.Request.Feedback;
using Presentation.Contracts.Response.Feedback;
using Presentation.Mappers.User;
using System.Runtime.CompilerServices;

namespace Presentation.Mappers.Feedback
{
    public static class FeedbackMapper
    {
        public static CreateFeedbackCommand ToCommand(this CreateFeedbackContract contract)
            => new CreateFeedbackCommand(contract.Content, contract.Visibility, contract.Reviewer, contract.Reviewee);

        public static CreateFeedbackResponse ToResponse(this Domain.Models.Feedbacks.Feedback feedback)
        {
            return new CreateFeedbackResponse 
            {
                Content = feedback.Content,
                Visibility = feedback.Visibility,
                Reviewee = feedback.Reviewee.ToUserDto(),
                Reviewer = feedback.Reviewer.ToUserDto(),
                SubmissionTimestamp = feedback.SubmissionTimestamp
            };
        }

        public static FeedbackDto ToLatestFeedbackResponse(this Domain.Models.Feedbacks.Feedback feedback)
        {
            return new FeedbackDto
            {
                Content = feedback.Content,
                Reviewer = feedback.Reviewer.ToUserDto(),
                Visibility = feedback.Visibility,
                SubmissionTimestamp = feedback.SubmissionTimestamp
            };
        }
    }
}
