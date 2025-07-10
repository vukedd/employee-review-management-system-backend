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
        public string Name { get; set; }
        public EvaluationType Type { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<ConcreteEvaluation> ConcreteEvaluations { get; set; }
        public IEnumerable<EvaluationPeriodEvaluation> EvaluationPeriodEvaluations { get; set; }

        public Evaluation()
        {
            Questions = new List<Question>();
            ConcreteEvaluations = new List<ConcreteEvaluation>();
            EvaluationPeriodEvaluations = new List<EvaluationPeriodEvaluation>();
        }
    }
}
