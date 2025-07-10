namespace Presentation.Contracts.Response.ConcreteEvaluation
{
    public class GetSubmittedEvaluationDto
    {
        public long Id { get; set; }
        public string Reviewer { get; set; }
        public string Reviewee { get; set; }
    }
}
