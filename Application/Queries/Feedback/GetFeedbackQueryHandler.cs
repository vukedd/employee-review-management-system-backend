using Application.Common.Exceptions;
using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Feedback
{
    public class GetFeedbackQueryHandler : IRequestHandler<GetFeedbackQuery, Domain.Models.Feedbacks.Feedback?>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public GetFeedbackQueryHandler(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<Domain.Models.Feedbacks.Feedback?> Handle(GetFeedbackQuery request, CancellationToken cancellationToken)
        {
            var feedback = await _feedbackRepository.GetLatestFeedbackAsyncByUsername(request.username);
            if (feedback == null)
                throw new NotFoundException("You haven't received any feedbacks yet!");
            
            return feedback;
        }
    }
    public record GetFeedbackQuery(string username): IRequest<Domain.Models.Feedbacks.Feedback?>;
}
