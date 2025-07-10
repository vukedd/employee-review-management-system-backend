using Application.Queries.ConcreteEvaluation;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Request.ConcreteEvaluation;
using Presentation.Contracts.Response.ConcreteEvaluation;
using Presentation.Mappers.ConcreteEvaluation;

namespace Presentation.Endpoints.ConcreteEvaluation
{
    public class GetSubmittedEvaluations : Endpoint<GetSubmittedEvaluationRequest, IEnumerable<GetSubmittedEvaluationDto>>
    {
        private IMediator _mediator;
        public GetSubmittedEvaluations(IMediator mediator) 
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("concreteEvaluation/submitted");
            Roles("MANAGER");
        }

        public override async Task<IEnumerable<GetSubmittedEvaluationDto>> ExecuteAsync(GetSubmittedEvaluationRequest req, CancellationToken ct)
        {
            var submittedEvaluations = await _mediator.Send(new GetSubmittedEvaluationsQuery(req.TeamId, req.CycleId));
            return submittedEvaluations.Select(se => se.ToSubmittedDto());
        }
    }
}
