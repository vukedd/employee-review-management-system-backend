using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Membership
{
    public class GetMembershipsByUsernameQueryHandler : IRequestHandler<GetMembershipsByUsernameQuery, IEnumerable<Domain.Models.Memberships.Membership>>
    {
        private readonly IMembershipRepository _membershipRepository;
        public GetMembershipsByUsernameQueryHandler(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public async Task<IEnumerable<Domain.Models.Memberships.Membership>> Handle(GetMembershipsByUsernameQuery request, CancellationToken cancellationToken)
        {
            var memberships = await _membershipRepository.GetMembershipsByUsernameAsync(request.username);
            return memberships;
        }
    }

    public record GetMembershipsByUsernameQuery(string username) : IRequest<IEnumerable<Domain.Models.Memberships.Membership>>;
}
