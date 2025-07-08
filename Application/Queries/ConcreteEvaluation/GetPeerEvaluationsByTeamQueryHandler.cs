using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ConcreteEvaluation
{
    public class GetPeerEvaluationsByTeamQueryHandler : IRequestHandler<GetPeerEvaluationsByTeamQuery, IEnumerable<Domain.Models.Evaluations.ConcreteEvaluation>>
    {
        private readonly IConcreteEvaluationRepository _concreteEvaluationRepository;
        public GetPeerEvaluationsByTeamQueryHandler(IConcreteEvaluationRepository concreteEvaluationRepository)
        {
            _concreteEvaluationRepository = concreteEvaluationRepository;
        }

        public async Task<IEnumerable<Domain.Models.Evaluations.ConcreteEvaluation>> Handle(GetPeerEvaluationsByTeamQuery request, CancellationToken cancellationToken)
        {
            var evaluations = await _concreteEvaluationRepository.GetPeerEvaluationsByTeamId(request.teamId);
            return evaluations;
        }
    }

    public record GetPeerEvaluationsByTeamQuery(long teamId): IRequest<IEnumerable<Domain.Models.Evaluations.ConcreteEvaluation>> { };
}
