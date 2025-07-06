using Application.Queries.Team;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.Team;
using Presentation.Mappers.Team;

namespace Presentation.Endpoints.Team
{
    public class GetById : EndpointWithoutRequest<GetTeamByIdResponse>
    {
        private readonly IMediator _mediator;
        public GetById(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("team/{id}");
            Roles("EMPLOYEE", "MANAGER");
        }

        public override async Task<GetTeamByIdResponse> ExecuteAsync(CancellationToken ct)
        {
            var teamId = Route<long>("id");
            var team = await _mediator.Send(new GetTeamByIdQuery(teamId));
            return team.ToGetByIdResponse();
        }
    }
}
