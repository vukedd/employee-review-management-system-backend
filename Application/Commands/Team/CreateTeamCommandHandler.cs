using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Mappers.Team;
using Domain.Models.Memberships;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Team
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, Domain.Models.Memberships.Team>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;
        public CreateTeamCommandHandler(IUserRepository userRepository, ITeamRepository teamRepository)
        {
            _userRepository = userRepository;
            _teamRepository = teamRepository;
        }
        public async Task<Domain.Models.Memberships.Team> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = request.ToDomainEntity();
            var memberships = team.Memberships.ToList();

            if (_teamRepository.GetTeamByName(team.Name) == null)
                throw new ConflictException("A team with the given name already exists!");

            var newTeam = new Domain.Models.Memberships.Team
            {
                Name = team.Name
            };
            
            foreach (Membership m in memberships)
            {
                var user = await _userRepository.GetUserById(m.UserId);
                if (user == null)
                    throw new NotFoundException($"A user with an id {m.UserId} doesn't exist!");

                if (user.Role == Domain.Enums.User.Role.MANAGER)
                    throw new UnprocessableException($"A user you specified is not an employee!");

                newTeam.Memberships.Add(new Membership
                {
                    User = user,
                    IsTeamLead = m.IsTeamLead
                });
            }

            newTeam = await _teamRepository.CreateTeamAsync(newTeam);
            return newTeam;
            
        }
    }

    public record CreateTeamCommand(string Name, IEnumerable<MembershipDto> Memberships) : IRequest<Domain.Models.Memberships.Team>;
}
