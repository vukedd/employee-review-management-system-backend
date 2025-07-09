using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Team
{
    public class GetAllTeamsQueryHandler : IRequestHandler<GetAllTeamsQuery, IEnumerable<Domain.Models.Memberships.Team>>
    {
        private readonly ITeamRepository _teamRepository;
        public GetAllTeamsQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public async Task<IEnumerable<Domain.Models.Memberships.Team>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await _teamRepository.GetAllTeams();
            return teams;
        }
    }
    public record GetAllTeamsQuery() : IRequest<IEnumerable<Domain.Models.Memberships.Team>> { }
}
