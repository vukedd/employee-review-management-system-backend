using FastEndpoints;
using MediatR;
using Presentation.Contracts.Request.Feedback;
using Presentation.Contracts.Response.Feedback;
using Presentation.Mappers.Feedback;

namespace Presentation.Endpoints.Feedback
{
    public class Create : Endpoint<CreateFeedbackContract, CreateFeedbackResponse>
    {
        private readonly IMediator _mediator;
        public Create(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Post("feedback/create");
            Roles("MANAGER", "EMPLOYEE");
        }

        public override async Task<CreateFeedbackResponse> ExecuteAsync(CreateFeedbackContract req, CancellationToken ct)
        {
            var newFeedback = await _mediator.Send(req.ToCommand(), ct);
            return newFeedback.ToResponse();
        }
    }
}
