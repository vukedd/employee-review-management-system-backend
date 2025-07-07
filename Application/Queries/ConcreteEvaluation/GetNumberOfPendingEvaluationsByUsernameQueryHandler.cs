using Application.Common.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ConcreteEvaluation
{
    public class GetPendingEvaluationCountByUsernameQueryHandler : IRequestHandler<GetPendingEvaluationCountByUsernameQuery, int>
    {
        private readonly IConcreteEvaluationRepository _concreteEvaluationRepository;
        public GetPendingEvaluationCountByUsernameQueryHandler(IConcreteEvaluationRepository concreteEvaluationRepository)
        {
            _concreteEvaluationRepository = concreteEvaluationRepository;
        }

        public async Task<int> Handle(GetPendingEvaluationCountByUsernameQuery request, CancellationToken cancellationToken)
        {
            return await _concreteEvaluationRepository.GetPendingEvaluationCountByUsername(request.username);
        }
    }

    public record GetPendingEvaluationCountByUsernameQuery(string username) : IRequest<int>;
}
