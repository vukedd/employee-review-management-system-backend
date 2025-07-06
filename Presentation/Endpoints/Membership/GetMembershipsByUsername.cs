using Application.Queries.Membership;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.Membership;
using Presentation.Mappers.Membership;

namespace Presentation.Endpoints.Membership
{
    public class GetMembershipsByUsername : EndpointWithoutRequest<IEnumerable<GetMembershipByUsernameResponse>>
    {
        private readonly IMediator _mediator;
        public GetMembershipsByUsername(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("membership/{username}");
            Roles("MANAGER", "EMPLOYEE");
        }

        public async override Task<IEnumerable<GetMembershipByUsernameResponse>> ExecuteAsync(CancellationToken ct)
        {
            var username = Route<String>("username");
            var memberships = await _mediator.Send(new GetMembershipsByUsernameQuery(username));

            return memberships.Select(m => m.ToGetByUsernameResponse()).ToList();
        }
    }
}
