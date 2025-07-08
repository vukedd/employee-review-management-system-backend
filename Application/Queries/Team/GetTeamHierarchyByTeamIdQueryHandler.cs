using Application.Common.Repositories;
using MediatR;

namespace Application.Queries.Team
{
    public class GetTeamHierarchyByTeamIdQueryHandler : IRequestHandler<GetTeamHierarchyByTeamIdQuery, IEnumerable<Domain.Models.Memberships.Membership>>
    {
        private readonly IMembershipRepository _membershipRepository;
        public GetTeamHierarchyByTeamIdQueryHandler(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public async Task<IEnumerable<Domain.Models.Memberships.Membership>> Handle(GetTeamHierarchyByTeamIdQuery request, CancellationToken cancellationToken)
        {
            var memberships = await _membershipRepository.GetMembershipsByTeamId(request.teamId);
            return memberships;
        }
    }

    public record GetTeamHierarchyByTeamIdQuery(long teamId) : IRequest<IEnumerable<Domain.Models.Memberships.Membership>> { }
}
