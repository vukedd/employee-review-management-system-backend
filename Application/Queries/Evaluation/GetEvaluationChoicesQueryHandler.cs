using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Evaluation
{
    public class GetEvaluationChoicesQueryHandler : IRequestHandler<GetEvaluationChoicesQuery, IEnumerable<Domain.Models.Evaluations.Evaluation>>
    {
        private readonly IEvaluationRepository _evaluationRepository;
        public GetEvaluationChoicesQueryHandler(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public async Task<IEnumerable<Domain.Models.Evaluations.Evaluation>> Handle(GetEvaluationChoicesQuery request, CancellationToken cancellationToken)
        {
            return await _evaluationRepository.GetEvaluationChoices();
        }
    }
    public record GetEvaluationChoicesQuery() : IRequest<IEnumerable<Domain.Models.Evaluations.Evaluation>> { }
}
