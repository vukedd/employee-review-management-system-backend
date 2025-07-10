using Domain.Models.Evaluations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories
{
    public interface IEvaluationRepository
    {
        public Task<Evaluation> CreateEvaluationAsync(Evaluation evaluation);
        public Task<Evaluation?> GetEvaluationByIdAsync(long id);
        public Task<List<Evaluation>> GetEvaluationByEvaluationPeriodIdAsync(long evaluationPeriodId);
        public Task<IEnumerable<Evaluation>> GetEvaluationChoices();

    }
}
