using FastEndpoints;
using MediatR;
using Presentation.Contracts.Request.EvaluationPeriod;
using Presentation.Contracts.Response.Evaluations.Create;
using Presentation.Mappers.Evaluations;

namespace Presentation.Endpoints.EvaluationPeriod
{
    public class Create : Endpoint<CreateEvaluationPeriodContract, CreateEvaluationPeriodResponse>
    {
        private readonly IMediator _mediator;
        public Create(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Post("evaluationPeriod");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateEvaluationPeriodContract req, CancellationToken ct)
        {
            var product = await _mediator.Send(req.ToCreateCommand(), ct);
            await SendOkAsync(product.ToCreateResponse(), ct);
        }
    }
}
