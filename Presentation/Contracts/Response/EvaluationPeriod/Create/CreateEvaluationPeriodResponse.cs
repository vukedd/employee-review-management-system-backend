namespace Presentation.Contracts.Response.EvaluationPeriod.Create
{
    public class CreateEvaluationPeriodResponse
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
