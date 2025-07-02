using Domain.Models.Evaluations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories
{
    public interface IConcreteEvaluationRepository
    {
        public Task CreateConcreteEvaluationRange(List<ConcreteEvaluation> concreteEvaluationList);
        public Task<IEnumerable<ConcreteEvaluation>> GetPendingEvaluationsByUsername(string username);
    }
}
