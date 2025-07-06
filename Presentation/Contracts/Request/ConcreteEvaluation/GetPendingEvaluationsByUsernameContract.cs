namespace Presentation.Contracts.Request.ConcreteEvaluation
{
    public class GetPendingEvaluationsByUsernameContract
    {
        public string Username { get; set; } = String.Empty;
        public long Filter { get; set; }
        public long TeamId { get; set; }
    }
}
