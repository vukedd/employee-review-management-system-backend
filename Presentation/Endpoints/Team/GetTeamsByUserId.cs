using Application.Queries.Team;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.Team;
using Presentation.Mappers.Team;

namespace Presentation.Endpoints.Team
{
    public class GetTeamsByUserId : EndpointWithoutRequest<List<CreateTeamResponse>>
    {
        public IMediator _mediator;
        public GetTeamsByUserId(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("team/by-user/{id}");
        }

        public override async Task<List<CreateTeamResponse>> ExecuteAsync(CancellationToken ct)
        {
            var userId = Route<long>("id");
            var teams = await _mediator.Send(new GetTeamsByUserIdQuery(userId));

            return teams.Select(t => t.ToCreateResponse()).ToList();
        }
    }
}
