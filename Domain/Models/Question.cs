using Domain.Enums;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Models
{
    public class Question
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public QuestionType Type { get; set; }
        public QuestionCategory Category { get; set; }

        public Question(string content, QuestionType type, QuestionCategory category)
        {
            Content = content;
            Type = type;
            Category = category;
        }
    }
}