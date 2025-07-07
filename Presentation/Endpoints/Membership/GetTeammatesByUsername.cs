using Application.Queries.Membership;
using Application.Queries.Team;
using FastEndpoints;
using MediatR;

namespace Presentation.Endpoints.Membership
{
    public class GetTeammatesByUsername : EndpointWithoutRequest<IEnumerable<string>>
    {
        private readonly IMediator _mediator;
        public GetTeammatesByUsername(IMediator mediator)
        {
            _mediator  = mediator;
        }

        public override void Configure()
        {
            Get("membership/collegues/{username}");
            Roles("EMPLOYEE", "MANAGER");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var username = Route<string>("username");
            var collegues = await _mediator.Send(new GetTeammatesByUsernameQuery(username));

            await SendOkAsync(collegues);
        }
    }
}
