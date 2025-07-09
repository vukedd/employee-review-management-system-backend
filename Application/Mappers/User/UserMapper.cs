using Application.Commands.User;
using Application.Common.DTOs;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.User
{
    public static class UserMapper
    {
        public static Domain.Models.Users.User ToDomainEntity(this RegisterUserCommand command)
        {
            return new Domain.Models.Users.User(
                    command.Username,
                    command.Password,
                    command.Email,
                    command.FirstName,
                    command.LastName,
                    Domain.Enums.User.Role.EMPLOYEE
            );
        }

        public static UserChoiceAppDto ToChoiceDto(this Domain.Models.Memberships.Membership membership)
        {
            return new UserChoiceAppDto
            {
                Id = membership.User.Id,
                Name = membership.User.Username,
                IsTeamLead = membership.IsTeamLead,

            };
        }


    }
}
