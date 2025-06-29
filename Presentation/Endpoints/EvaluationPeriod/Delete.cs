using Application.Commands.Evaluations;
using Application.Queries.Evaluations;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.EvaluationPeriod.Delete;
using Presentation.Contracts.Response.EvaluationPeriod.Get;

namespace Presentation.Endpoints.EvaluationPeriod
{
    public class Delete : EndpointWithoutRequest<DeleteEvaluationPeriodResponse>
    {
        private readonly IMediator _mediator;
        public Delete(IMediator mediator) 
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Delete("evaluationPeriod/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var evaluationPeriodId = Route<long>("id");

            await _mediator.Send(new DeleteEvaluationPeriodCommand(evaluationPeriodId), ct);

            await SendNoContentAsync(ct);
        }
    }
}
