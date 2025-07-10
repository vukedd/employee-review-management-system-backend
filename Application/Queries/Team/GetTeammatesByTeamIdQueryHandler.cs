using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Team
{
    public class GetTeammatesByTeamIdQueryHandler : IRequestHandler<GetTeammatesByTeamIdQuery, IEnumerable<Domain.Models.Memberships.Membership>>
    {
        private readonly IMembershipRepository _membershipRepository;
        public GetTeammatesByTeamIdQueryHandler(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public async Task<IEnumerable<Domain.Models.Memberships.Membership>> Handle(GetTeammatesByTeamIdQuery request, CancellationToken cancellationToken)
        {
            var teammates = await _membershipRepository.GetTeammatesByTeamId(request.teamId);
            return teammates;
        }
    }

    public record GetTeammatesByTeamIdQuery(long teamId) : IRequest<IEnumerable<Domain.Models.Memberships.Membership>> { }
}
