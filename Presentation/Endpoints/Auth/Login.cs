using Application.Commands.User;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Presentation.Contracts.Request.User;
using Presentation.Mappers.User;

namespace Presentation.Endpoints.Auth
{
    public class Login : Endpoint<LoginUserContract, TokenResponse>
    {
        private readonly IMediator _mediator;
        public Login(IMediator mediator) 
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Post("auth/login");
            AllowAnonymous();
        }

        public override async Task<TokenResponse> ExecuteAsync(LoginUserContract req, CancellationToken ct)
        {
            var token = await _mediator.Send(req.ToLoginCommand(), ct);

            return token;
        }
    }
}
