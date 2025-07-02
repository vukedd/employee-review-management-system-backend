namespace Presentation.Contracts.Request.EvaluationPeriod
{
    public class CreateEvaluationPeriodContract
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<long> EvaluationIds { get; set; } = new List<long>();
    }
}
