namespace Presentation.Contracts.Request.ConcreteEvaluation
{
    public class GetPendingEvaluationByIdContract
    {
        public long EvaluationId { get; set; }

        public GetPendingEvaluationByIdContract(long id)
        {
            EvaluationId = id;
        }
    }
}
