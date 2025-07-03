using FastEndpoints;
using FastEndpoints.Swagger;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Presentation.Contracts.Request.ConcreteEvaluation;
using Presentation.Contracts.Response.ConcreteEvaluation;
using Presentation.Mappers.ConcreteEvaluation;
using System.Runtime.CompilerServices;

namespace Presentation.Endpoints.ConcreteEvaluation
{
    public class GetPendingEvaluationById : EndpointWithoutRequest<GetPendingEvaluationByIdResponse>
    {
        private readonly IMediator _mediator;
        public GetPendingEvaluationById(IMediator mediator)
        {
            _mediator = mediator; 
        }

        public override void Configure()
        {
            Get("concreteEvaluation/{id}");
            Roles("EMPLOYEE", "MANAGER");
        }

        public async override Task<GetPendingEvaluationByIdResponse> ExecuteAsync(CancellationToken ct)
        {
            var evaluationId = Route<long>("id");

            var pendingEvaluation = await _mediator.Send(new GetPendingEvaluationByIdContract(evaluationId).ToQuery());
            return pendingEvaluation.ToResponseById();
        }
    }
}
