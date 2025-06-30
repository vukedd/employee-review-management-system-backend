using Application.Common.DTOs;
using Presentation.Contracts.Request.Question;
using Presentation.Contracts.Response.Question;
using System.Diagnostics.Contracts;

namespace Presentation.Mappers.Question
{
    public static class QuestionMapper
    {
        public static QuestionDto ToQuestionDto(this CreateQuestionContract contract)
        {
            return new QuestionDto
            {
                Content = contract.Content,
                Category = contract.Category,
                Type = contract.Type
            };

        }

        public static CreateQuestionResponse ToCreateResponse(this Domain.Models.Evaluations.EvaluationComponents.Question question)
        {
            return new CreateQuestionResponse
            {
                Content = question.Content,
                Category = question.Category,
                Type = question.Type
            };
        }
    }
}
