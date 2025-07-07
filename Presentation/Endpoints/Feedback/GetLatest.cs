using Application.Queries.Feedback;
using FastEndpoints;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using Presentation.Contracts.Request.Feedback;
using Presentation.Contracts.Response.Feedback;
using Presentation.Mappers.Feedback;

namespace Presentation.Endpoints.Feedback
{
    public class GetLatest : EndpointWithoutRequest<FeedbackDto>
    {
        private readonly IMediator _mediator;
        public GetLatest(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Get("feedback/latest/{username}");
            Roles("EMPLOYEE", "MANAGER");
        }
        public async override Task<FeedbackDto> ExecuteAsync(CancellationToken ct)
        {
            var username = Route<string>("username");
            var feedback = await _mediator.Send(new GetFeedbackQuery(username));
            return feedback.ToLatestFeedbackResponse();
        }
    }
}
