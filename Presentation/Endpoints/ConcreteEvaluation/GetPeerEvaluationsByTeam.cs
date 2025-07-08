using Application.Queries.ConcreteEvaluation;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Response.ConcreteEvaluation;
using Presentation.Mappers.ConcreteEvaluation;

namespace Presentation.Endpoints.ConcreteEvaluation
{
    public class GetPeerEvaluationsByTeam : EndpointWithoutRequest<List<GetPeerEvaluationByTeamResponse>>
    {
        private readonly IMediator _mediator;
        public GetPeerEvaluationsByTeam(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("concreteEvaluation/peer/{teamId}");
            Roles("MANAGER", "EMPLOYEE");
        }

        public override async Task<List<GetPeerEvaluationByTeamResponse>> ExecuteAsync(CancellationToken ct)
        {
            var teamId = Route<long>("teamId");
            var evaluations = await _mediator.Send(new GetPeerEvaluationsByTeamQuery(teamId));
            return evaluations.Select(e => e.ToGetPeerResponse()).ToList();
        }
    }
}
