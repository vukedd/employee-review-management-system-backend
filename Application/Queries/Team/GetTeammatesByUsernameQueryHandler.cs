using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Team
{
    public class GetTeammatesByUsernameQueryHandler : IRequestHandler<GetTeammatesByUsernameQuery, IEnumerable<string>>
    {
        private readonly ITeamRepository _teamRepository;
        public GetTeammatesByUsernameQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IEnumerable<string>> Handle(GetTeammatesByUsernameQuery request, CancellationToken cancellationToken)
        {
            var collegues = await _teamRepository.GetTeammatesByUsername(request.username);
            return collegues;
        }
    }

    public record GetTeammatesByUsernameQuery(string username) : IRequest<IEnumerable<string>>;
}
