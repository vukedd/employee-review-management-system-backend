using Application.Common.DTOs;
using Domain.Models.Evaluations.EvaluationComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.Evaluations.EvaluationComponents
{
    public static class QuestionMapper
    {
        public static Question ToDomainEntity(this QuestionDto questionDto)
        {
            return new Question
            {
                Category = questionDto.Category,
                Type = questionDto.Type,
                Content = questionDto.Content,
            };

        }
    }
}
