using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Team
{
    public class GetTeamsByUsernameQueryHandler : IRequestHandler<GetTeamsByUsernameQuery, IEnumerable<Domain.Models.Memberships.Team>>
    {
        private ITeamRepository _teamRepository;
        public GetTeamsByUsernameQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<Domain.Models.Memberships.Team>> Handle(GetTeamsByUsernameQuery request, CancellationToken cancellationToken)
        {
            var teams = await _teamRepository.GetTeamsByUsername(request.username);
            return teams;
        }
    }

    public record GetTeamsByUsernameQuery(string username) : IRequest<IEnumerable<Domain.Models.Memberships.Team>>;
}
