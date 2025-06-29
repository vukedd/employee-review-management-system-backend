using Application.Commands.Evaluations;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Presentation.Contracts.Request.EvaluationPeriod;
using Presentation.Contracts.Response.EvaluationPeriod.Edit;
using Presentation.Mappers.Evaluations;

namespace Presentation.Endpoints.EvaluationPeriod
{
    public class Edit : Endpoint<EditEvaluationPeriodContract, EditEvaluationPeriodResponse>
    {
        private readonly IMediator _mediator;
        public Edit(IMediator mediator)
        {
            _mediator = mediator;            
        }

        public override void Configure()
        {
            Put("evaluationPeriod/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(EditEvaluationPeriodContract req, CancellationToken ct)
        {
            var evaluationPeriodId = Route<long>("id");

            var product = await _mediator.Send(req.ToEditCommand(evaluationPeriodId), ct);
            await SendOkAsync(product.ToEditResponse(), ct);
        }
    }
}
