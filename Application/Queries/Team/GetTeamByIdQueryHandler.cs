using Application.Common.Exceptions;
using Application.Common.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Team
{
    public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, Domain.Models.Memberships.Team>
    {
        private readonly ITeamRepository _teamRepository;
        public GetTeamByIdQueryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public async Task<Domain.Models.Memberships.Team> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetTeamById(request.teamId);

            if (team == null)
                throw new NotFoundException("The team you were looking for couldn't be found!");

            return team;
        }
    }

    public record GetTeamByIdQuery(long teamId) : IRequest<Domain.Models.Memberships.Team>;
}
