using Domain.Enums.Evaluation;
using Presentation.Contracts.Request.Question;
using Presentation.Contracts.Response.Question;

namespace Presentation.Contracts.Response.Evaluation
{
    public class CreateEvaluationResponse
    {
        public EvaluationType Type { get; set; }
        public IEnumerable<CreateQuestionResponse> Questions { get; set; } = new List<CreateQuestionResponse>();
    }
}
