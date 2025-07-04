using FastEndpoints;
using MediatR;
using Presentation.Contracts.Request.Auth;
using Presentation.Contracts.Response.Auth;
using Presentation.Mappers.RefreshToken;

namespace Presentation.Endpoints.Auth
{
    public class Logout : Endpoint<LogoutContract, LogoutResponse>
    {
        private readonly IMediator _mediator;
        public Logout(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Post("auth/logout");
            Roles("EMPLOYEE", "MANAGER");
        }

        public override async Task<LogoutResponse> ExecuteAsync(LogoutContract req, CancellationToken ct)
        {
            var token = await _mediator.Send(req.ToCommand());
            return new LogoutResponse
            {
                Message = "You have succesfully logged in!"
            };

        }
    }
}
