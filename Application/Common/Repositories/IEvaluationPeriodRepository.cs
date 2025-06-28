using Domain.Models.Evaluations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories
{
    public interface IEvaluationPeriodRepository
    {
        public Task<EvaluationPeriod> CreateEvaluationPeriodAsync(EvaluationPeriod evaluationPeriod);
        public Task<ICollection<EvaluationPeriod>> GetAllEvaluationPeriods();
        public Task<EvaluationPeriod> GetEvaluationPeriodById(long evaluationPeriodId);

    }
}
