namespace Presentation.Contracts.Response.Evaluations.Get
{
    public class GetEvaluationPeriodByIdResponse
    {
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
