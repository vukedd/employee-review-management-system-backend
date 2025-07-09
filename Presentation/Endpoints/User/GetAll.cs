using Application.Queries.User;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.User;
using Presentation.Mappers.User;

namespace Presentation.Endpoints.User
{
    public class GetAll : EndpointWithoutRequest<IEnumerable<UserChoiceDto>>
    {
        private readonly IMediator _mediator;
        public GetAll(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("user/choice");
            Roles("MANAGER", "EMPLOYEE");
        }

        public async override Task<IEnumerable<UserChoiceDto>> ExecuteAsync(CancellationToken ct)
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return users.Select(u => u.ToUserChoiceDto());
        }
    }
}
