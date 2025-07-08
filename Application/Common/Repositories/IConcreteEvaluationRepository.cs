using Application.Common.Enums;
using Domain.Models.Evaluations;
using Domain.Models.Evaluations.EvaluationComponents;
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
        public Task<IEnumerable<ConcreteEvaluation>> GetPendingEvaluationsByUsername(string username, EvaluationFilter filter, long TeamId);
        public Task<ConcreteEvaluation?> GetConcreteEvaluationById(long evalId);
        public Task<ConcreteEvaluation?> EditConcreteEvaluation(long id, List<Response> responses);
        public Task<int> GetPendingEvaluationCountByUsername(string username);
        public Task<IEnumerable<ConcreteEvaluation>> GetPeerEvaluationsByTeamId(long teamId);
    }
}
