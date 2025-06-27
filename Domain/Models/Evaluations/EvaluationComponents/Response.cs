using Domain.Enums.Response;

namespace Domain.Models.Evaluations.EvaluationComponents
{
    public class Response
    {
        public long Id { get; set; }
        public ResponseType Type { get; set; }
        public string? Content { get; set; }
        public long QuestionId { get; set; }
        public Question? Question { get; set; }
        public long ConcreteEvaluationId { get; set; }
        public ConcreteEvaluation? ConcreteEvaluation { get; set; }
        public Response() { }

        public Response(ResponseType type, long questionId, long concreteEvaluationId, string? content = null)
        {
            Type = type;
            QuestionId = questionId;
            ConcreteEvaluationId = concreteEvaluationId;
            Content = content;
        }
    }
}