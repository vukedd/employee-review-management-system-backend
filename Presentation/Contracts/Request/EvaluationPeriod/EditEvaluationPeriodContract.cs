namespace Presentation.Contracts.Request.EvaluationPeriod
{
    public class EditEvaluationPeriodContract
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
