using Application.Common.DTOs;
using Application.Common.Enums;
using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ConcreteEvaluation
{
    public class GetEvaluationStatisticsQueryHandler : IRequestHandler<GetEvaluationStatisticsQuery, StatisticsDto>
    {
        private readonly IConcreteEvaluationRepository _concreteEvaluationRepository;
        public GetEvaluationStatisticsQueryHandler(IConcreteEvaluationRepository concreteEvaluationRepository)
        {
            _concreteEvaluationRepository = concreteEvaluationRepository;
        }

        public async Task<StatisticsDto> Handle(GetEvaluationStatisticsQuery request, CancellationToken cancellationToken)
        {
            var pending = await _concreteEvaluationRepository.GetEvaluationCount(request.cycleId, request.teamId, EvaluationStatisticsFilter.PENDING);
            var missed = await  _concreteEvaluationRepository.GetEvaluationCount(request.cycleId, request.teamId, EvaluationStatisticsFilter.MISSED);
            var submitted = await _concreteEvaluationRepository.GetEvaluationCount(request.cycleId, request.teamId, EvaluationStatisticsFilter.SUBMITTED);
            var total = await _concreteEvaluationRepository.GetEvaluationCount(request.cycleId, request.teamId, EvaluationStatisticsFilter.ALL);

            return new StatisticsDto 
            { 
                pendingEvaluations = pending,
                missedEvaluations = missed,
                submittedEvaluations = submitted,
                totalEvaluations = total
            };

        }
    }

    public record GetEvaluationStatisticsQuery(long teamId, long cycleId) : IRequest<StatisticsDto> { }
}
