using Application.Commands.Team;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Request.Team;
using Presentation.Contracts.Response.Team;
using Presentation.Mappers.Membership;
using Presentation.Mappers.Team;

namespace Presentation.Endpoints.Team
{
    public class Edit : Endpoint<EditTeamContract, EditTeamResponse>
    {
        private readonly IMediator _mediator;
        public Edit(IMediator mediator)
        {
            _mediator = mediator;    
        }

        public override void Configure()
        {
            Put("team/{id}");
            Roles("MANAGER");
        }

        public override async Task<EditTeamResponse> ExecuteAsync(EditTeamContract req, CancellationToken ct)
        {
            var teamId = Route<long>("id");
            var editResult = await _mediator.Send(new EditTeamCommand(teamId, req.Name, req.Memberships.Select(m => m.ToMembershipDto()).ToList()));
            return editResult.ToEditResponse();
        }
    }
}
