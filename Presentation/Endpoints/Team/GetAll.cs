using Application.Queries.Team;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Request.Team;
using Presentation.Mappers.Team;

namespace Presentation.Endpoints.Team
{
    public class GetAll : EndpointWithoutRequest<IEnumerable<TeamDisplayDto>>
    {
        private readonly IMediator _mediator;
        public GetAll(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("team");
            Roles("MANAGER");
        }

        public async override Task<IEnumerable<TeamDisplayDto>> ExecuteAsync(CancellationToken ct)
        {
            var teams = await _mediator.Send(new GetAllTeamsQuery());
            return teams.Select(t => t.ToDisplayDto());
        }
    }
}
