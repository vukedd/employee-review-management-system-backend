using Application.Queries.Feedback;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.Feedback;
using Presentation.Mappers.Feedback;

namespace Presentation.Endpoints.Feedback
{
    public class GetFeedbackByUsername : EndpointWithoutRequest<IEnumerable<FeedbackDto>>
    {
        private readonly IMediator _mediator;
        public GetFeedbackByUsername(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("feedback/{username}");
            Roles("EMPLOYEE", "MANAGER");
        }

        public async override Task<IEnumerable<FeedbackDto>> ExecuteAsync(CancellationToken ct)
        {
            var username = Route<string>("username");
            var feedbacks = await _mediator.Send(new GetFeedbacksByUsernameQuery(username));
            return feedbacks.Select(f => f.ToLatestFeedbackResponse());
        }
    }
}
