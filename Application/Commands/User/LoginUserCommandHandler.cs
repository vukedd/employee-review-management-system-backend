using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Common.Services;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, TokenResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;

        public LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<TokenResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsername(request.Username);

            if (user == null)
                throw new UnauthorizedException("The entered credentials are invalid!");

            var isPasswordCorrect = await _passwordHasher.VerifyPasswordAsync(request.Password, user.Password);

            if (!isPasswordCorrect)
                throw new UnauthorizedException("The entered credentials are invalid!");

            var tokens = await _jwtService.GenerateTokensAsync(user.Username, user.Role.ToString());

            return tokens;
        }
    }

    public record LoginUserCommand(string Username, string Password) : IRequest<TokenResponse>;
    public record TokenResponse(string AccessToken);
}
