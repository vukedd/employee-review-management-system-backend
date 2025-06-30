using Application.Queries.EvaluationPeriod;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.EvaluationPeriod.Get;
using Presentation.Mappers.EvaluationPeriod;

namespace Presentation.Endpoints.EvaluationPeriod
{
    public class GetById : EndpointWithoutRequest<GetEvaluationPeriodByIdResponse>
    {
        private readonly IMediator _mediator;
        public GetById(IMediator mediator) 
        {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Get("evaluationPeriod/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var evaluationPeriodId = Route<long>("id");

            var evaluationPeriod = await _mediator.Send(new GetEvaluationPeriodByIdQuery(evaluationPeriodId), ct);
            await SendOkAsync(evaluationPeriod.ToGetByIdResponse(), ct);
        }
    }
}
