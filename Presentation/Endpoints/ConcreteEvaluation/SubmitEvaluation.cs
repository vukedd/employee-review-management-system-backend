using FastEndpoints;
using MediatR;
using Presentation.Contracts.Request.ConcreteEvaluation;
using Presentation.Contracts.Response.ConcreteEvaluation;
using Presentation.Mappers.ConcreteEvaluation;

namespace Presentation.Endpoints.ConcreteEvaluation
{
    public class SubmitEvaluation : Endpoint<SubmitEvaluationRequestContract, SubmitEvaluationResponseContract>
    {
        private IMediator _mediator;
        public SubmitEvaluation(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Put("concreteEvaluation/submit");
            Roles("EMPLOYEE");
        }

        public override async Task<SubmitEvaluationResponseContract> ExecuteAsync(SubmitEvaluationRequestContract req, CancellationToken ct)
        {
            var submittedEvaluation = await _mediator.Send(req.ToCommand());
            return submittedEvaluation.ToSubmitResponse();
        }

    }
}
