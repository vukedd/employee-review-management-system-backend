using Application.Queries.Team;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.Team;
using Presentation.Mappers.Team;

namespace Presentation.Endpoints.Team
{
    public class GetTeamChoice : EndpointWithoutRequest<IEnumerable<TeamChoiceDto>>
    {
        private readonly IMediator _mediator;
        public GetTeamChoice(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Roles("MANAGER");
            Get("team/choice");
        }

        public override async Task<IEnumerable<TeamChoiceDto>> ExecuteAsync(CancellationToken ct)
        {
            var choices = await _mediator.Send(new GetAllTeamsQuery());
            return choices.Select(t => t.ToTeamChoice()).ToList();
        }
    }
}
