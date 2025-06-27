namespace Domain.Models.Evaluations
{
    public class EvaluationPeriodEvaluation
    {
        public long Id { get; set; }
        public long EvaluationId { get; set; }
        public long EvaluationPeriodId { get; set; }
        public Evaluation? Evaluation { get; set; }
        public EvaluationPeriod? EvaluationPeriod { get; set; }
    }
}