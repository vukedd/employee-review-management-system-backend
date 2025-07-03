using Application.Common.Exceptions;
using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ConcreteEvaluation
{
    public class GetPendingEvaluationByIdQueryHandler : IRequestHandler<GetPendingEvaluationByIdQuery, Domain.Models.Evaluations.ConcreteEvaluation>
    {
        private IConcreteEvaluationRepository _concreteEvaluationRepository;
        public GetPendingEvaluationByIdQueryHandler(IConcreteEvaluationRepository concreteEvaluationRepository)
        {
            _concreteEvaluationRepository = concreteEvaluationRepository;
        }

        public async Task<Domain.Models.Evaluations.ConcreteEvaluation> Handle(GetPendingEvaluationByIdQuery request, CancellationToken cancellationToken)
        {
            var pendingEvaluation = await _concreteEvaluationRepository.GetPendingEvaluationById(request.evalId);
            
            if (pendingEvaluation == null)
                throw new NotFoundException("The evaluation form you are looking for hasn't been found");

            return pendingEvaluation;
        }
    }

    public record GetPendingEvaluationByIdQuery (long evalId) : IRequest<Domain.Models.Evaluations.ConcreteEvaluation>;
}
