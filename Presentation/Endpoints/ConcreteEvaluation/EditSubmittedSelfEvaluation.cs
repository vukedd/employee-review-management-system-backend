using FastEndpoints;
using MediatR;
using Microsoft.Identity.Client;
using Presentation.Contracts.Request.ConcreteEvaluation;
using Presentation.Contracts.Response.ConcreteEvaluation;

namespace Presentation.Endpoints.ConcreteEvaluation
{
    public class EditSubmittedSelfEvaluation : Endpoint<EditSelfEvaluationContract, EditSelfEvaluationResponse>
    {
        private readonly IMediator _mediator;
        public EditSubmittedSelfEvaluation(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
