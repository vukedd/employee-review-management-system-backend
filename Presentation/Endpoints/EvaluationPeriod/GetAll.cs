using Application.Queries.EvaluationPeriod;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.EvaluationPeriod.Get;
using Presentation.Mappers.EvaluationPeriod;

namespace Presentation.Endpoints.EvaluationPeriod
{
    public class GetAll : EndpointWithoutRequest<List<GetEvaluationPeriodResponse>>
    {
        private readonly IMediator _mediator;
        public GetAll(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("evaluationPeriod");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var evaluationPeriodList = await _mediator.Send(new GetAllEvaluationPeriodsQuery(), ct);
            List<GetEvaluationPeriodResponse> evaluationPeriods = new List<GetEvaluationPeriodResponse>();
            foreach (var item in evaluationPeriodList)
            {
                evaluationPeriods.Add(item.ToGetResponse());  
            }

            await SendOkAsync(evaluationPeriods);
        }
    }
}
