using Domain.Enums.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DTOs
{
    public class QuestionDto
    {
        public string Content { get; set; } = String.Empty;
        public QuestionType Type { get; set; }
        public QuestionCategory Category { get; set; }
    }
}
