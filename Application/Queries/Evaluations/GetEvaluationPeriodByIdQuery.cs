using Application.Commands.Evaluations;
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
    public class GetEvaluationPeriodByIdQueryHandler : IRequestHandler<GetEvaluationPeriodByIdQuery, EvaluationPeriod>
    {
        private readonly IEvaluationPeriodRepository _evaluationPeriodRepository;
        public GetEvaluationPeriodByIdQueryHandler(IEvaluationPeriodRepository evaluationPeriodRepository)
        {
            _evaluationPeriodRepository = evaluationPeriodRepository;
        }

        public async Task<EvaluationPeriod> Handle(GetEvaluationPeriodByIdQuery request, CancellationToken cancellationToken)
        {
            var evaluationPeriod = await _evaluationPeriodRepository.GetEvaluationPeriodById(request.evaluationPeriodId);
            return evaluationPeriod;
        }
    }

    public record GetEvaluationPeriodByIdQuery(long evaluationPeriodId) : IRequest<EvaluationPeriod>;

}
