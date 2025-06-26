using Domain.Enums;

namespace Domain.Models
{
    public class Response
    {
        public long Id { get; set; }
        public ResponseType ResponseType { get; set; }
        public Question? Question { get; set; }
        public long QuestionId { get; set; }
        public ConcreteEvaluation? ConcreteEvaluation { get; set; }
        public long ConcreteEvaluationId { get; set; }

        public Response(ResponseType type, long questionId, long concreteEvaluationId)
        {
            this.ResponseType = type;
            this.QuestionId = questionId;
            this.ConcreteEvaluationId = concreteEvaluationId;
        }
    }
}