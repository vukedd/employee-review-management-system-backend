using Application.Common.Exceptions;
using FastEndpoints;
using MediatR;
using Presentation.Contracts.Request.ConcreteEvaluation;
using Presentation.Contracts.Response.ConcreteEvaluation;
using Presentation.Mappers.ConcreteEvaluation;
using System.Security.Claims;

namespace Presentation.Endpoints.ConcreteEvaluation
{
    public class EditSubmittedSelfEvaluation : Endpoint<EditSelfEvaluationContract, EditSelfEvaluationResponse>
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EditSubmittedSelfEvaluation(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;            _httpContextAccessor = httpContextAccessor;
        }

        public override void Configure()
        {
            Put("concreteEvaluation/edit");
            Roles("EMPLOYEE");
        }

        public override async Task<EditSelfEvaluationResponse?> ExecuteAsync(EditSelfEvaluationContract req, CancellationToken ct)
        {
            var username = User.FindFirst("unique_name")?.Value;
            if (username != req.Reviewer.Username)
                throw new UnauthorizedException("You don't have the permission to modify this evaluation!");

            var modifiedForm = await _mediator.Send(req.ToEditCommand());
            return modifiedForm.ToEditResponse();
        }
    }
}
