using Application.Commands.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.Feedback
{
    public static class FeedbackMapper
    {
        public static Domain.Models.Feedbacks.Feedback ToDomainEntity(this CreateFeedbackCommand feedback)
        {
            return new Domain.Models.Feedbacks.Feedback
            {
                Content = feedback.Content,
                Visibility = feedback.Visibility,
                RevieweeId = feedback.RevieweeId,
                ReviewerId = feedback.ReviewerId,
            };
        }
    }
}
