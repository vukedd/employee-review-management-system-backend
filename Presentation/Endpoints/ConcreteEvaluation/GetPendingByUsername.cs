using FastEndpoints;
using MediatR;
using Presentation.Contracts.Request.ConcreteEvaluation;
using Presentation.Contracts.Response.ConcreteEvaluation;
using Presentation.Mappers.ConcreteEvaluation;

namespace Presentation.Endpoints.ConcreteEvaluation
{
    public class GetPendingByUsername : Endpoint<GetPendingEvaluationsByUsernameContract, IEnumerable<GetPendingEvaluationsByUsernameResponse>>
    {
        public IMediator _mediator;
        public GetPendingByUsername(IMediator mediator) 
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("concreteEvaluation");
            Roles("EMPLOYEE");
        }

        public override async Task<IEnumerable<GetPendingEvaluationsByUsernameResponse>> ExecuteAsync(GetPendingEvaluationsByUsernameContract req, CancellationToken ct)
        {
            var pendingEvaluations = await _mediator.Send(req.ToQuery());
            return pendingEvaluations.Select(pe => pe.ToResponse()).ToList();
        }
    }
}
