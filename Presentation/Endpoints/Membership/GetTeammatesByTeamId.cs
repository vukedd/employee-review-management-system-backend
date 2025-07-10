using Application.Queries.Team;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.User;
using Presentation.Mappers.Membership;

namespace Presentation.Endpoints.Membership
{
    public class GetTeammatesByTeamId : EndpointWithoutRequest<IEnumerable<TeammateDto>>
    {
        private IMediator _mediator;
        public GetTeammatesByTeamId(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("membership/teammates/{teamId}");
            Roles("EMPLOYEE", "MANAGER");
        }

        public override async Task<IEnumerable<TeammateDto>> ExecuteAsync(CancellationToken ct)
        {
            var teamId = Route<long>("teamId");
            var teammates = await _mediator.Send(new GetTeammatesByTeamIdQuery(teamId));
            return teammates.Select(t => t.ToTeammateDto()).ToList();
        }
    }
}
