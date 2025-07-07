using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Feedback
{
    public class GetFeedbacksByUsernameQueryHandler : IRequestHandler<GetFeedbacksByUsernameQuery, IEnumerable<Domain.Models.Feedbacks.Feedback>>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public GetFeedbacksByUsernameQueryHandler(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public Task<IEnumerable<Domain.Models.Feedbacks.Feedback>> Handle(GetFeedbacksByUsernameQuery request, CancellationToken cancellationToken)
        {
            var feedbackList = _feedbackRepository.GetFeedbacksByUsername(request.username);
            return feedbackList;
        }
    }
    public record GetFeedbacksByUsernameQuery(string username) : IRequest<IEnumerable<Domain.Models.Feedbacks.Feedback>>;
}
