using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ConcreteEvaluation
{
    public class GetSubmittedEvaluationsQueryHandler : IRequestHandler<GetSubmittedEvaluationsQuery, IEnumerable<Domain.Models.Evaluations.ConcreteEvaluation>>
    {
        private readonly IConcreteEvaluationRepository _concreteEvaluationRepository;
        public GetSubmittedEvaluationsQueryHandler(IConcreteEvaluationRepository concreteEvaluationRepository)
        {
            _concreteEvaluationRepository = concreteEvaluationRepository;
        }

        public async Task<IEnumerable<Domain.Models.Evaluations.ConcreteEvaluation>> Handle(GetSubmittedEvaluationsQuery request, CancellationToken cancellationToken)
        {
            var submittedEvaluations = await _concreteEvaluationRepository.GetSubmittedEvaluations(request.cycleId, request.teamId);
            return submittedEvaluations;
        }
    }
    public record GetSubmittedEvaluationsQuery(long teamId, long cycleId) : IRequest<IEnumerable<Domain.Models.Evaluations.ConcreteEvaluation>> { }
}
