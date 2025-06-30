using Domain.Enums.Question;

namespace Presentation.Contracts.Request.Question
{
    public class CreateQuestionContract
    {
        public string Content { get; set; } = String.Empty;
        public QuestionType Type { get; set; }
        public QuestionCategory Category { get; set; }
    }
}
