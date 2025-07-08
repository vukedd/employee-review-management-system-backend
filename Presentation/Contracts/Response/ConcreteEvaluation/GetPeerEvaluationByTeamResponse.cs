using Domain.Enums.Evaluation;

namespace Presentation.Contracts.Response.ConcreteEvaluation
{
    public class GetPeerEvaluationByTeamResponse
    {
        public long Id { get; set; }
        public string Reviewee { get; set; }
        public string Reviewer { get; set; }
        public bool Pending { get; set; }
        public EvaluationType Type { get; set; }
        public DateOnly? Deadline { get; set; }
    }
}
