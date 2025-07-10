namespace Presentation.Contracts.Request.ConcreteEvaluation
{
    public class GetSubmittedEvaluationRequest
    {
        public long TeamId { get; set; }
        public long CycleId { get; set; }
    }
}
