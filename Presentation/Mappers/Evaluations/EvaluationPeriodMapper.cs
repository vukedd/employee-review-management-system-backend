using Application.Commands.Evaluations;
using Application.Queries.Evaluations;
using Domain.Models.Evaluations;
using Presentation.Contracts.Request.Evaluations.Create;
using Presentation.Contracts.Request.Evaluations.Get;
using Presentation.Contracts.Response.Evaluations.Create;
using Presentation.Contracts.Response.Evaluations.Get;

namespace Presentation.Mappers.Evaluations
{
    public static class EvaluationPeriodMapper
    {
        public static CreateEvaluationPeriodCommand ToCreateCommand(this CreateEvaluationPeriodContract contract) 
            => new CreateEvaluationPeriodCommand(contract.StartDate, contract.EndDate, contract.Name, contract.Description);

        public static CreateEvaluationPeriodResponse ToCreateResponse(this EvaluationPeriod entity)
        {
            return new CreateEvaluationPeriodResponse
            {
                StartDate = (DateOnly)entity.StartDate,
                EndDate = (DateOnly)entity.EndDate,
                Name = entity.Name,
                Description = entity.Description,
            };
        }

        public static GetEvaluationPeriodByIdQuery ToGetByIdQuery(this GetEvaluationPeriodByIdContract contract)
            => new GetEvaluationPeriodByIdQuery(contract.id);
        public static GetEvaluationPeriodByIdResponse ToGetByIdResponse(this EvaluationPeriod entity)
        {
            return new GetEvaluationPeriodByIdResponse
            {
                StartDate = (DateOnly)entity.StartDate,
                EndDate = (DateOnly)entity.EndDate,
                Name = entity.Name,
                Description = entity.Description,
            };
        }
    }
}
