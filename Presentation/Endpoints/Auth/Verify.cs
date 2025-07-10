using Application.Commands.Auth;
using Domain.Models.Users;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.User;
using Presentation.Mappers.User;

namespace Presentation.Endpoints.Auth
{
    public class Verify : EndpointWithoutRequest
    {
        private readonly IMediator _mediator;
        public Verify(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("auth/verify/{token}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var token = Route<string>("token");

            try
            {
                await _mediator.Send(new VerifyAccountCommand(token), ct);

                const string successUrl = "http://localhost:4200?verification=success";
                await SendRedirectAsync(location: successUrl, allowRemoteRedirects: true);
            }
            catch (Exception ex)
            {

                const string failureUrl = "http://localhost:4200?verification=failed";
                await SendRedirectAsync(location: failureUrl, allowRemoteRedirects: true);
            }
        }
    }
}
