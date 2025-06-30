using Domain.Models.Users;
using Presentation.Contracts.Request.User;
using Presentation.Contracts.Response.User;

namespace Presentation.Mappers.User
{
    public static class UserMapper
    {
        public static Application.Commands.User.RegisterUserCommand ToRegisterCommand(this RegisterUserContract contract)
        {
            return new Application.Commands.User
                .RegisterUserCommand(contract.Username,
                contract.Password,
                contract.Email,
                contract.FirstName,
                contract.LastName);
        }

        public static RegisterUserResponse ToRegisterResponse(this Domain.Models.Users.User contract)
        {
            return new RegisterUserResponse
            {
                Username = contract.Username,
                Password = contract.Password,
                Email = contract.Email,
                FirstName = contract.FirstName,
                LastName = contract.LastName,
            };
        }
    }
}

