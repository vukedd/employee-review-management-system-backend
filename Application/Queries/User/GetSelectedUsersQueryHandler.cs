using Application.Common.DTOs;
using Application.Common.Repositories;
using Application.Mappers.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.User
{
    public class GetSelectedUsersQueryHandler : IRequestHandler<GetSelectedUsersQuery, IEnumerable<UserChoiceAppDto>>
    {
        public IMembershipRepository _membershipRepository { get; set; }
        public GetSelectedUsersQueryHandler(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }
        public async Task<IEnumerable<UserChoiceAppDto>> Handle(GetSelectedUsersQuery request, CancellationToken cancellationToken)
        {
            var memberships = await _membershipRepository.GetMembershipsByTeamId(request.TeamId);

            return memberships.Select(m => m.ToChoiceDto());
        }
    }

    public record GetSelectedUsersQuery(long TeamId): IRequest<IEnumerable<UserChoiceAppDto>> { };
}
