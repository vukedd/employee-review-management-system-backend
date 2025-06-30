using FastEndpoints;
using MediatR;
using Presentation.Contracts.Request.Evaluation;
using Presentation.Contracts.Response.Evaluation;
using Presentation.Mappers.Evaluation;

namespace Presentation.Endpoints.Evaluation
{
    public class Create : Endpoint<CreateEvaluationContract, CreateEvaluationResponse>
    {
        private readonly IMediator _mediator;
        public Create(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Post("evaluation/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateEvaluationContract req, CancellationToken ct)
        {
            var addedEvaluation = await _mediator.Send(req.ToCreateCommand(), ct);
            await SendOkAsync(addedEvaluation.ToCreateResponse());
        }
    }
}
