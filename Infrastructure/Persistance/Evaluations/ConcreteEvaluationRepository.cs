using Application.Common.Enums;
using Application.Common.Repositories;
using Domain.Models.Evaluations;
using Domain.Models.Evaluations.EvaluationComponents;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Evaluations
{
    public class ConcreteEvaluationRepository : IConcreteEvaluationRepository
    {
        private readonly AppDbContext _context;
        public ConcreteEvaluationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateConcreteEvaluationRange(List<ConcreteEvaluation> concreteEvaluationList)
        {
            await _context.ConcreteEvaluations.AddRangeAsync(concreteEvaluationList);
            await _context.SaveChangesAsync();
        }

        public async Task<ConcreteEvaluation?> GetConcreteEvaluationById(long evalId)
        {
            return await _context.ConcreteEvaluations.Include("Responses")
                .Include("Reviewee")
                .Include("Reviewer")
                .Include("Evaluation.Questions")
                .Include("EvaluationPeriod")
                .Where(ev => ev.Id == evalId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ConcreteEvaluation>> GetPendingEvaluationsByUsername(string username, EvaluationFilter filter, long TeamId)
        {
            var currDate = DateOnly.FromDateTime(DateTime.Now);
            List<ConcreteEvaluation> validPendingEvaluations = new List<Domain.Models.Evaluations.ConcreteEvaluation>();
            var evaluationQuery = _context.ConcreteEvaluations.Where(eval => eval.Reviewer.Username == username)
                .Include(eval => eval.Evaluation)
                .ThenInclude(eval => eval.EvaluationPeriodEvaluations)
                .Include(eval => eval.EvaluationPeriod)
                .Include("Reviewer")
                .Include("Reviewee");

            switch (filter) 
            {
                case EvaluationFilter.PENDING:
                    if (TeamId > 0)
                        evaluationQuery = evaluationQuery.Where(eval => eval.Pending
                        && eval.EvaluationPeriod.EndDate >= currDate && eval.TeamId == TeamId);
                    else
                        evaluationQuery = evaluationQuery.Where(eval => eval.Pending
                        && eval.EvaluationPeriod.EndDate >= currDate);

                    break;

                case EvaluationFilter.MISSED:
                    if (TeamId > 0)
                        evaluationQuery = evaluationQuery.Where(eval => eval.Pending
                        && eval.EvaluationPeriod.EndDate < currDate && eval.TeamId == TeamId);
                    else
                        evaluationQuery = evaluationQuery.Where(eval => eval.Pending
                        && eval.EvaluationPeriod.EndDate < currDate);
                    
                    break;

                case EvaluationFilter.EVALUATED:
                    if (TeamId > 0)
                        evaluationQuery = evaluationQuery.Where(eval => !eval.Pending 
                        && eval.TeamId == TeamId);
                    else
                        evaluationQuery = evaluationQuery.Where(eval => !eval.Pending);
                    
                    break;
            }

            return await evaluationQuery.ToListAsync();
        }

        public async Task<ConcreteEvaluation?> EditConcreteEvaluation(long id, List<Response> responses)
        {
            var evaluation = await _context.ConcreteEvaluations.Where(ce => ce.Id == id)
                .Include("Responses")
                .Include("Reviewee")
                .Include("Reviewer")
                .Include("Evaluation.Questions")
                .FirstOrDefaultAsync();

            if (evaluation != null)
            {
                for (int i = 0; i < responses.Count; i++)
                {
                    evaluation.Responses[i].Content = responses[i].Content;
                }
                evaluation.SubmissionTimestamp = DateTime.Now;
                evaluation.Pending = false;
                await _context.SaveChangesAsync();
            }

            return evaluation;
        }

        public async Task<int> GetPendingEvaluationCountByUsername(string username)
        {
            return await _context.ConcreteEvaluations.Where(ce => ce.Reviewer.Username == username && ce.Pending == true).CountAsync();
        }
    }
}
