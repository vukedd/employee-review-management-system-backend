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
    public class EditTeamCommandHandler : IRequestHandler<EditTeamCommand, Domain.Models.Memberships.Team>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IUserRepository _userRepository;
        public EditTeamCommandHandler(ITeamRepository teamRepository, IUserRepository userRepository)
        {
            _teamRepository = teamRepository;
            _userRepository = userRepository;
        }

        public async Task<Domain.Models.Memberships.Team> Handle(EditTeamCommand request, CancellationToken cancellationToken)
        {
            var team = request.ToDomain2Entity();
            var memberships = team.Memberships.ToList();

            var nameCheck = await _teamRepository.GetTeamByName(team.Name);
            if (nameCheck != null && nameCheck.Id != (await _teamRepository.GetTeamById(request.Id)).Id)
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

            newTeam = await _teamRepository.EditTeam(request.Id, newTeam);
            return newTeam;
        }
    }

    public record EditTeamCommand(long Id, string Name, IEnumerable<MembershipDto> Memberships) : IRequest<Domain.Models.Memberships.Team>;
}
