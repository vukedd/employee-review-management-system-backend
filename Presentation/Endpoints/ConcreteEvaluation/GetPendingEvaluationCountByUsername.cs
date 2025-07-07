using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Presentation.Contracts.Request.ConcreteEvaluation;
using Presentation.Mappers.ConcreteEvaluation;

namespace Presentation.Endpoints.ConcreteEvaluation
{
    public class GetPendingEvaluationCountByUsername : Endpoint<GetPendingEvaluationCoundByUsernameRequest, int>
    {
        private readonly IMediator _mediator;
        public GetPendingEvaluationCountByUsername(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get("concreteEvaluation/count/{username}");
            Roles("EMPLOYEE", "MANAGER");
        }

        public override async Task<int> ExecuteAsync(GetPendingEvaluationCoundByUsernameRequest req, CancellationToken ct)
        {
            var count = await _mediator.Send(req.ToCountQuery());
            return count;
        }
    }
}
