using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Mappers.Feedback;
using Domain.Enums.Feedback;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Feedback
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, Domain.Models.Feedbacks.Feedback>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMembershipRepository _membershipRepository;
        public CreateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IUserRepository userRepository, IMembershipRepository membershipRepository)
        {
            _feedbackRepository = feedbackRepository;   
            _userRepository = userRepository;
            _membershipRepository = membershipRepository;
        }

        public async Task<Domain.Models.Feedbacks.Feedback> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedbackEntity = request.ToDomainEntity();

            var reviewer = await _userRepository.GetUserById(feedbackEntity.ReviewerId);
            if (reviewer == null)
                throw new NotFoundException("The reviewer you have selected hasn't been found!");

            var reviewee = await _userRepository.GetUserById(feedbackEntity.RevieweeId);

            if (reviewee == null)
                throw new NotFoundException("The reviewee you have selected hasn't been found!");

            var reviewerMemberships = await _membershipRepository.GetMembershipsByUserIdAsync(reviewer.Id);
            var revieweeMemberships = await _membershipRepository.GetMembershipsByUserIdAsync(reviewee.Id);

            HashSet<long> reviewerTeams = reviewerMemberships.Select(m => m.TeamId).ToHashSet();
            HashSet<long> revieweeTeams = revieweeMemberships.Select(m => m.TeamId).ToHashSet();

            if (revieweeTeams.Intersect(reviewerTeams).Count() == 0)
                throw new UnprocessableException("The reviewer and reviewee must be from the same team!");


            feedbackEntity.Reviewee = reviewee;
            feedbackEntity.Reviewer = reviewer;

            var addedFeedback = await _feedbackRepository.CreateFeedbackAsync(feedbackEntity);
            return addedFeedback;
        }
    }

    public record CreateFeedbackCommand(string Content, Visibility Visibility, long ReviewerId, long RevieweeId) : IRequest<Domain.Models.Feedbacks.Feedback> { }
}
