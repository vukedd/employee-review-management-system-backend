using Application.Commands.Evaluations;
using Domain.Models.Evaluations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.Evaluations
{
    public static class EvaluationPeriodMapper
    {
        public static EvaluationPeriod ToDomainEntity(this CreateEvaluationPeriodCommand command)
        {
            return new EvaluationPeriod
            {
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                Name = command.Name,
                Description = command.Description,
            };
        }
    }
}
