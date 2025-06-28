using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.Request.Evaluations;
using Presentation.Contracts.Request.Evaluations.Create;
using Presentation.Contracts.Request.Evaluations.Get;
using Presentation.Contracts.Response.Evaluations.Create;
using Presentation.Contracts.Response.Evaluations.Get;
using Presentation.Mappers.Evaluations;

namespace Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EvaluationPeriodController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EvaluationPeriodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateEvaluationPeriodResponse>> CreateEvaluationPeriod(CreateEvaluationPeriodContract request) {
            var evaluationPeriod = await _mediator.Send(request.ToCreateCommand());
            return Ok(evaluationPeriod.ToCreateResponse());
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<ActionResult<GetEvaluationPeriodByIdResponse>> GetEvaluationPeriodById(long id)
        {
            var evaluationPeriod = await _mediator.Send(new GetEvaluationPeriodByIdContract(id).ToGetByIdQuery());

            if (evaluationPeriod == null)
            {
                return NotFound("The evaluation period you were looking for wasn't found!");
            }

            return Ok(evaluationPeriod);
        }
    }
}
