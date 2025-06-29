namespace Presentation.Contracts.Response.EvaluationPeriod.Edit
{
    public class EditEvaluationPeriodResponse
    {
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
