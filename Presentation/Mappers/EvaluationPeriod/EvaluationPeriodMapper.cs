using Application.Commands.EvaluationPeriod;
using Application.Queries.EvaluationPeriod;
using Domain.Models.Evaluations;
using Presentation.Contracts.Request.EvaluationPeriod;
using Presentation.Contracts.Response.EvaluationPeriod.Create;
using Presentation.Contracts.Response.EvaluationPeriod.Edit;
using Presentation.Contracts.Response.EvaluationPeriod.Get;

namespace Presentation.Mappers.EvaluationPeriod
{
    public static class EvaluationPeriodMapper
    {
        #region create
        public static CreateEvaluationPeriodCommand ToCreateCommand(this CreateEvaluationPeriodContract contract)
            => new CreateEvaluationPeriodCommand(contract.StartDate, contract.EndDate, contract.Name, contract.Description, contract.EvaluationIds);

        public static CreateEvaluationPeriodResponse ToCreateResponse(this Domain.Models.Evaluations.EvaluationPeriod entity)
        {
            return new CreateEvaluationPeriodResponse
            {
                StartDate = (DateOnly)entity.StartDate,
                EndDate = (DateOnly)entity.EndDate,
                Name = entity.Name,
                Description = entity.Description,
                EvaluationIds = entity.EvaluationPeriodEvaluations.Select(epe => epe.EvaluationId).ToList()
            };
        }
        #endregion

        #region getById
        public static GetEvaluationPeriodByIdQuery ToGetByIdQuery(this GetEvaluationPeriodByIdContract contract)
            => new GetEvaluationPeriodByIdQuery(contract.id);
        public static GetEvaluationPeriodByIdResponse ToGetByIdResponse(this Domain.Models.Evaluations.EvaluationPeriod entity)
        {
            return new GetEvaluationPeriodByIdResponse
            {
                StartDate = (DateOnly)entity.StartDate,
                EndDate = (DateOnly)entity.EndDate,
                Name = entity.Name,
                Description = entity.Description,
            };
        }

        #endregion

        #region getAll
        public static GetEvaluationPeriodResponse ToGetResponse(this Domain.Models.Evaluations.EvaluationPeriod entity)
        {
            return new GetEvaluationPeriodResponse
            {
                StartDate = (DateOnly)entity.StartDate,
                EndDate = (DateOnly)entity.EndDate,
                Name = entity.Name,
                Description = entity.Description,
            };
        }

        #endregion

        #region edit
        public static EditEvaluationPeriodCommand ToEditCommand(this EditEvaluationPeriodContract contract, long id)
            => new EditEvaluationPeriodCommand(id, contract.StartDate, contract.EndDate, contract.Name, contract.Description);
        
        public static EditEvaluationPeriodResponse ToEditResponse(this Domain.Models.Evaluations.EvaluationPeriod entity)
        {
            return new EditEvaluationPeriodResponse
            {
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Name = entity.Name,
                Description = entity.Description,
            };
        }

        #endregion

    }
}
