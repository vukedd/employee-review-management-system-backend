using Application.Common.Enums;
using Application.Common.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ConcreteEvaluation
{
    public class GetPendingEvaluationsQueryHandler : IRequestHandler<GetPendingEvaluationsQuery, IEnumerable<Domain.Models.Evaluations.ConcreteEvaluation>>
    {
        private readonly IConcreteEvaluationRepository _concreteEvaluationRepository;
        public GetPendingEvaluationsQueryHandler(IConcreteEvaluationRepository concreteEvaluationRepository) 
        {
            _concreteEvaluationRepository = concreteEvaluationRepository;
        }

        public async Task<IEnumerable<Domain.Models.Evaluations.ConcreteEvaluation>> Handle(GetPendingEvaluationsQuery request, CancellationToken cancellationToken)
        {
            var pendingEvaluations = await _concreteEvaluationRepository
                .GetPendingEvaluationsByUsername(request.Username, (EvaluationFilter)request.Filter, request.TeamId);            

            return pendingEvaluations;

        }
    }

    public record GetPendingEvaluationsQuery(string Username, long Filter, long TeamId) : IRequest<IEnumerable<Domain.Models.Evaluations.ConcreteEvaluation>> { }
}
