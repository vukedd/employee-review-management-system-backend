using FastEndpoints;
using MediatR;
using Presentation.Contracts.Request.Auth;
using Presentation.Contracts.Response.Auth;
using Presentation.Mappers.RefreshToken;

namespace Presentation.Endpoints.Auth
{
    public class Refresh : Endpoint<RefreshTokenContract, RefreshTokenResponse>
    {
        private readonly IMediator _mediator;
        public Refresh(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("auth/refresh");
            Roles("EMPLOYEE", "MANAGER");
        }

        public async override Task<RefreshTokenResponse> ExecuteAsync(RefreshTokenContract req, CancellationToken ct)
        {
            var accessToken = await _mediator.Send(req.ToQuery());
            return new RefreshTokenResponse(accessToken);
        }
    }
}
