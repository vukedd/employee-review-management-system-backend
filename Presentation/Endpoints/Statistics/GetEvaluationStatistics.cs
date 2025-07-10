using Application.Common.DTOs;
using Application.Queries.ConcreteEvaluation;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Request.Statistics;

namespace Presentation.Endpoints.Statistics
{
    public class GetEvaluationStatistics : Endpoint<StatisticsRequest, StatisticsDto>
    {
        private readonly IMediator _mediator;
        public GetEvaluationStatistics(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("evaluationPeriod/statistics");
            Roles("MANAGER");
        }

        public async override Task<StatisticsDto> ExecuteAsync(StatisticsRequest req, CancellationToken ct)
        {
            var statistics = await _mediator.Send(new GetEvaluationStatisticsQuery(req.teamId, req.cycleId));
            return statistics;
        }
    }
}
