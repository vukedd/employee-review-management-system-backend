using FastEndpoints;
using MediatR;
using Presentation.Contracts.Request.Team;
using Presentation.Contracts.Response.Team;
using Presentation.Mappers.Team;

namespace Presentation.Endpoints.Team
{
    public class Create : Endpoint<CreateTeamContract, CreateTeamResponse>
    {
        private readonly IMediator _mediator;
        public Create(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Post("team/create");
            Roles("MANAGER");
        }

        public override async Task<CreateTeamResponse> ExecuteAsync(CreateTeamContract req, CancellationToken ct)
        {
            var team = await _mediator.Send(req.ToCreateCommand(), ct);

            return team.ToCreateResponse();
        }
    }
}
