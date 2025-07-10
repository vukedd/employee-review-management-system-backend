using Application.Queries.Evaluation;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.Evaluation;
using Presentation.Mappers.Evaluation;
using YamlDotNet.Serialization;

namespace Presentation.Endpoints.Evaluation
{
    public class GetEvaluationChoices : EndpointWithoutRequest<IEnumerable<EvaluationChoiceDto>>
    {
        private IMediator _mediator;
        public GetEvaluationChoices(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Get("evaluation/choice");
            Roles("MANAGER");
        }
        public override async Task<IEnumerable<EvaluationChoiceDto>> ExecuteAsync(CancellationToken ct)
        {
            var evaluationChoices = await _mediator.Send(new GetEvaluationChoicesQuery());
            return evaluationChoices.Select(e => e.ToEvaluationChoice()).ToList();
        }
    }
}
