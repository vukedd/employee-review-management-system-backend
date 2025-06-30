using Domain.Enums.Evaluation;
using Presentation.Contracts.Request.Question;

namespace Presentation.Contracts.Request.Evaluation
{
    public class CreateEvaluationContract
    {
        public EvaluationType Type { get; set; }
        public IEnumerable<CreateQuestionContract>? Questions { get; set; }
    }
}
