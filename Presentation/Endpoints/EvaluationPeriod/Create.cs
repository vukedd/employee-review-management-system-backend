using FastEndpoints;
using MediatR;
using Presentation.Contracts.Request.EvaluationPeriod;
using Presentation.Contracts.Response.EvaluationPeriod.Create;
using Presentation.Mappers.EvaluationPeriod;

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
            Post("evaluationPeriod/create");
            Roles("MANAGER");
        }

        public override async Task HandleAsync(CreateEvaluationPeriodContract req, CancellationToken ct)
        {
            var evaluationPeriod = await _mediator.Send(req.ToCreateCommand(), ct);
            await SendOkAsync(evaluationPeriod.ToCreateResponse(), ct);
        }
    }
}
