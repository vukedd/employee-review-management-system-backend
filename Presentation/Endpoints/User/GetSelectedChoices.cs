using Application.Queries.User;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.User;
using Presentation.Mappers.User;

namespace Presentation.Endpoints.User
{
    public class GetSelectedChoices : EndpointWithoutRequest<IEnumerable<UserChoiceDto>>
    {
        private IMediator _mediator;
        public GetSelectedChoices(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Get("user/choice/{teamId}");
            Roles("MANAGER");
        }
        public override async Task<IEnumerable<UserChoiceDto>> ExecuteAsync(CancellationToken ct)
        {
            var teamId = Route<long>("teamId");
            var choices = await _mediator.Send(new GetSelectedUsersQuery(teamId));
            return choices.Select(u => u.ToUserChoicePresDto());
        }
    }
}
