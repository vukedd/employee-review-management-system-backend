using Application.Commands.Evaluation;
using Application.Mappers.Evaluations.EvaluationComponents;
using Domain.Models.Evaluations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.Evaluations
{
    public static class EvaluationMapper
    {
        public static Evaluation ToDomainEntity(this CreateEvaluationCommand command)
        {
            return new Evaluation
            {
                Name = command.name,
                Type = command.type,
                Questions = command.questions.Select(q => q.ToDomainEntity()).ToList(),
            };
        }


    }
}
