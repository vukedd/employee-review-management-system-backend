using Domain.Enums.Question;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Models.Evaluations.EvaluationComponents
{
    public class Question
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public QuestionType Type { get; set; }
        public QuestionCategory Category { get; set; }
        public long EvaluationId { get; set; }
        public Evaluation? Evaluation { get; set; }
        public ICollection<Response> Responses { get; set; }

        public Question()
        {
            Responses = new List<Response>();
        }
    }
}