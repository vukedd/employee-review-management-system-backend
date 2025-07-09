using Application.Commands.User;
using Domain.Models.Users;
using Presentation.Contracts.Request.User;
using Presentation.Contracts.Response.User;
using System.Runtime.CompilerServices;

namespace Presentation.Mappers.User
{
    public static class UserMapper
    {
        #region register
        public static Application.Commands.User.RegisterUserCommand ToRegisterCommand(this RegisterUserContract contract) 
            => new RegisterUserCommand(contract.Username,
                contract.Password,
                contract.Email,
                contract.FirstName,
                contract.LastName);

        public static RegisterUserResponse ToRegisterResponse(this Domain.Models.Users.User contract)
        {
            return new RegisterUserResponse
            {
                Username = contract.Username,
                Email = contract.Email,
                FirstName = contract.FirstName,
                LastName = contract.LastName,
            };
        }

        #endregion

        #region login
        public static LoginUserCommand ToLoginCommand(this LoginUserContract contract) =>
            new LoginUserCommand(contract.Username, contract.Password);
        #endregion

        #region other
        public static UserDto ToUserDto(this Domain.Models.Users.User user)
        {
            return new UserDto
            {
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public static UserChoiceDto ToUserChoiceDto(this Domain.Models.Users.User user)
        {
            return new UserChoiceDto
            {
                Id = user.Id,
                IsTeamLead = false,
                Name = user.Username
            };
        }

        public static UserChoiceDto ToUserChoicePresDto(this Application.Common.DTOs.UserChoiceAppDto choice)
        {
            return new UserChoiceDto()
            {
               Id = choice.Id,
               IsTeamLead = choice.IsTeamLead,
               Name = choice.Name,
            };
        }
        #endregion
    }
}

