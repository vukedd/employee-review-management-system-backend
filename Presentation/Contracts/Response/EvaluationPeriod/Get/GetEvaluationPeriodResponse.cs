namespace Presentation.Contracts.Response.EvaluationPeriod.Get
{
    public class GetEvaluationPeriodResponse
    {
        public DateOnly? StartDate {  get; set; }
        public DateOnly? EndDate { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }
}
