using Application.Common.Exceptions;
using Application.Common.Repositories;
using Domain.Models.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Auth
{
    public class VerifyAccountCommandHandler : IRequestHandler<VerifyAccountCommand, Domain.Models.Users.User>
    {
        private readonly IUserRepository _userRepository;
        public VerifyAccountCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Domain.Models.Users.User> Handle(VerifyAccountCommand request, CancellationToken cancellationToken)
        {
            var token = WebUtility.UrlDecode(request.token);
            var user = await _userRepository.GetUserByVerificationToken(token);

            if (user == null)
                throw new NotFoundException("Invalid token!");

            if (user.Verified)
                throw new ConflictException("Account is already verified!");

            await _userRepository.VerifyUser(user.Id);

            return user;
        }
    }

    public record VerifyAccountCommand(string token) : IRequest<Domain.Models.Users.User> { }
}
