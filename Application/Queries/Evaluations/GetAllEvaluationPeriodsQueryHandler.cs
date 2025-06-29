using Application.Common.Repositories;
using Domain.Models.Evaluations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Evaluations
{
    public class GetAllEvaluationPeriodsQueryHandler : IRequestHandler<GetAllEvaluationPeriodsQuery, IEnumerable<EvaluationPeriod>>
    {
        private readonly IEvaluationPeriodRepository _evaluationPeriodRepository;
        public GetAllEvaluationPeriodsQueryHandler(IEvaluationPeriodRepository evaluationPeriodRepository)
        {
            _evaluationPeriodRepository = evaluationPeriodRepository;
        }

        public Task<IEnumerable<EvaluationPeriod>> Handle(GetAllEvaluationPeriodsQuery request, CancellationToken cancellationToken)
        {
            var evaluationPeriods = _evaluationPeriodRepository.GetAllEvaluationPeriods();

            return evaluationPeriods;
        }
    }

    public record GetAllEvaluationPeriodsQuery() : IRequest<IEnumerable<EvaluationPeriod>>;
}
