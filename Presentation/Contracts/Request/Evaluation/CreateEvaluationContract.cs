using Domain.Enums.Evaluation;
using Presentation.Contracts.Request.Question;

namespace Presentation.Contracts.Request.Evaluation
{
    public class CreateEvaluationContract
    {
        public string Name { get; set; }
        public EvaluationType Type { get; set; }
        public IEnumerable<CreateQuestionContract>? Questions { get; set; }
    }
}
