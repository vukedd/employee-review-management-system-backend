using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Team
{
    public class GetTeamsByUserIdQueryHandler : IRequestHandler<GetTeamsByUserIdQuery, IEnumerable<Domain.Models.Memberships.Team>>
    {
        private ITeamRepository _teamRepository;
        public GetTeamsByUserIdQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<Domain.Models.Memberships.Team>> Handle(GetTeamsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var teams = await _teamRepository.GetTeamsByUserId(request.userId);
            return teams;
        }
    }

    public record GetTeamsByUserIdQuery(long userId) : IRequest<IEnumerable<Domain.Models.Memberships.Team>>;
}
