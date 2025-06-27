using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Evaluations
{
    public class EvaluationPeriod
    {
        public long Id { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<EvaluationPeriodEvaluation> EvaluationPeriodEvaluations { get; set; }

        public EvaluationPeriod()
        {
            EvaluationPeriodEvaluations = new List<EvaluationPeriodEvaluation>();
        }

        public EvaluationPeriod(DateOnly? startDate, DateOnly? endDate, string? name, string? description)
        {
            StartDate = startDate;
            EndDate = endDate;
            Name = name;
            Description = description;
            EvaluationPeriodEvaluations = new List<EvaluationPeriodEvaluation>();
        }
    }
}
