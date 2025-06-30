using Application.Common.Exceptions;
using Application.Common.Repositories;
using Domain.Models.Evaluations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.EvaluationPeriod
{
    public class GetEvaluationPeriodByIdQueryHandler : IRequestHandler<GetEvaluationPeriodByIdQuery, Domain.Models.Evaluations.EvaluationPeriod>
    {
        private readonly IEvaluationPeriodRepository _evaluationPeriodRepository;
        public GetEvaluationPeriodByIdQueryHandler(IEvaluationPeriodRepository evaluationPeriodRepository)
        {
            _evaluationPeriodRepository = evaluationPeriodRepository;
        }

        public async Task<Domain.Models.Evaluations.EvaluationPeriod> Handle(GetEvaluationPeriodByIdQuery request, CancellationToken cancellationToken)
        {
            var evaluationPeriod = await _evaluationPeriodRepository.GetEvaluationPeriodById(request.evaluationPeriodId);

            if (evaluationPeriod == null)
            {
                throw new NotFoundException($"An evalution period with the id: {request.evaluationPeriodId} hasn't been found!");
            }
            return evaluationPeriod;
        }
    }

    public record GetEvaluationPeriodByIdQuery(long evaluationPeriodId) : IRequest<Domain.Models.Evaluations.EvaluationPeriod>;

}
