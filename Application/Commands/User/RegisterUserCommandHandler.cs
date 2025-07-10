using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Common.Services;
using Application.Mappers.User;
using Domain.Models.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.User
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Domain.Models.Users.User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMailService _mailService;
        private readonly IUtils _utils;
        public RegisterUserCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher, 
            IMailService mailService,
            IUtils utils
        )
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mailService = mailService;
            _utils = utils;
        }
        public async Task<Domain.Models.Users.User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var usernameCheck = await _userRepository.GetUserByUsername(request.Username);
            if (usernameCheck != null) 
                throw new ConflictException("The given username is already taken!");


            var emailCheck = await _userRepository.GetUserByEmail(request.Email);
            if (emailCheck != null)
                throw new ConflictException("The given E-mail address is already taken!");


            var userEntity = request.ToDomainEntity();
            userEntity.Password = await _passwordHasher.HashPasswordAsync(userEntity.Password);

            var verificationToken = Guid.NewGuid().ToString();
            userEntity.VerificationToken = verificationToken;

            var registeredUser = await _userRepository.CreateAsync(userEntity);

            await _mailService.SendVerificationEmail(registeredUser.Email, WebUtility.UrlEncode(verificationToken));
            return registeredUser;
        }
    }

    public record RegisterUserCommand(string Username, string Password, string Email, string FirstName, string LastName) : IRequest<Domain.Models.Users.User>;
}
