using Application.Commands.Evaluation;
using Presentation.Contracts.Request.Evaluation;
using Presentation.Contracts.Request.EvaluationPeriod;
using Presentation.Contracts.Response.Evaluation;
using Presentation.Mappers.Question;

namespace Presentation.Mappers.Evaluation
{
    public static class EvaluationMapper
    {

        public static CreateEvaluationCommand ToCreateCommand(this CreateEvaluationContract contract)
            => new CreateEvaluationCommand(contract.Name, contract.Type, contract.Questions.Select(q => q.ToQuestionDto()));
    
        public static CreateEvaluationResponse ToCreateResponse(this Domain.Models.Evaluations.Evaluation evaluation)
        {
            return new CreateEvaluationResponse
            {
                Name = evaluation.Name,
                Type = evaluation.Type,
                Questions = evaluation.Questions.Select(q => q.ToCreateResponse())
            };
        }

        public static EvaluationChoiceDto ToEvaluationChoice(this Domain.Models.Evaluations.Evaluation evaluation)
        {
            return new EvaluationChoiceDto
            {
                Id = evaluation.Id,
                Name = evaluation.Name
            };
        }
    } 
}