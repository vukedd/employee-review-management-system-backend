namespace Presentation.Contracts.Request.EvaluationPeriod
{
    public class GetEvaluationPeriodByIdContract
    {
        public long id { get; set; }

        public GetEvaluationPeriodByIdContract(long id)
        {
            this.id = id;
        }
    }
}
