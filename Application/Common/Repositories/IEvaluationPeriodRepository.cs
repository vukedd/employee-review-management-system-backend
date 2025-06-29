using Domain.Models.Evaluations;

namespace Application.Common.Repositories
{
    public interface IEvaluationPeriodRepository
    {
        public Task<EvaluationPeriod> CreateEvaluationPeriodAsync(EvaluationPeriod evaluationPeriod);
        public Task<IEnumerable<EvaluationPeriod>> GetAllEvaluationPeriods();
        public Task<EvaluationPeriod?> GetEvaluationPeriodById(long evaluationPeriodId);
        public Task<EvaluationPeriod?> DeleteEvaluationPeriodById(long evaluationPeriodId);
        public Task<EvaluationPeriod?> EditEvaluationPeriodById(long evaluationPeriodId, EvaluationPeriod evaluationPeriod);
    }
}
