using Domain.Enums.Evaluation;
using Domain.Models.Evaluations.EvaluationComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Evaluations
{
    public class Evaluation
    {
        public long Id { get; set; }
        public EvaluationType Type { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<ConcreteEvaluation> ConcreteEvaluations { get; set; }
        public ICollection<EvaluationPeriodEvaluation> EvaluationPeriodEvaluations { get; set; }

        public Evaluation()
        {
            Questions = new List<Question>();
            ConcreteEvaluations = new List<ConcreteEvaluation>();
            EvaluationPeriodEvaluations = new List<EvaluationPeriodEvaluation>();
        }
    }
}
