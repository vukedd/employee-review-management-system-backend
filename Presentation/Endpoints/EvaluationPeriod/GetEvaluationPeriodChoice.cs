using Application.Queries.EvaluationPeriod;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.EvaluationPeriod.Get;
using Presentation.Mappers.EvaluationPeriod;

namespace Presentation.Endpoints.EvaluationPeriod
{
    public class GetEvaluationPeriodChoice : EndpointWithoutRequest<IEnumerable<GetEvaluationPeriodChoiceResponse>>
    {
        private readonly IMediator _mediator;
        public GetEvaluationPeriodChoice(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("evaluationPeriod/choice");
            Roles("MANAGER", "EMPLOYEE");
        }

        public override async Task<IEnumerable<GetEvaluationPeriodChoiceResponse>> ExecuteAsync(CancellationToken ct)
        {
            var choices = await _mediator.Send(new GetAllEvaluationPeriodsQuery());
            return choices.Select(c => c.ToGetEvaluationPeriodChoice()).ToList();
        }
    }
}
