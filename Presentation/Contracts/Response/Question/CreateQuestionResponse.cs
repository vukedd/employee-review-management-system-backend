using Domain.Enums.Question;

namespace Presentation.Contracts.Response.Question
{
    public class CreateQuestionResponse
    {
        public string Content { get; set; } = String.Empty;
        public QuestionType Type { get; set; }
        public QuestionCategory Category { get; set; }
    }
}
