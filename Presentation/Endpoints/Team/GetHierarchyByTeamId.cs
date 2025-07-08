using Application.Queries.Team;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.Team;
using Presentation.Mappers.Membership;

namespace Presentation.Endpoints.Team
{
    public class GetHierarchyByTeamId : EndpointWithoutRequest<TeamHierarchyResponse>
    {
        private readonly IMediator _mediator;
        public GetHierarchyByTeamId(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Roles("EMPLOYEE", "MANAGER");
            Get("team/hierarchy/{id}");
        }
        public override async Task<TeamHierarchyResponse> ExecuteAsync(CancellationToken ct)
        {
            var teamId = Route<long>("id");
            var memberships = await _mediator.Send(new GetTeamHierarchyByTeamIdQuery(teamId));
            return memberships.ToTeamHieararchyResponse();
        }
    }
}
