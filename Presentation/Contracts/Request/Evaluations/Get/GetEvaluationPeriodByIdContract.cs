namespace Presentation.Contracts.Request.Evaluations.Get
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
