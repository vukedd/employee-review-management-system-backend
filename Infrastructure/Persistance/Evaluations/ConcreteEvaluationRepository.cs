using Application.Common.Repositories;
using Domain.Models.Evaluations;
using Domain.Models.Evaluations.EvaluationComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<ConcreteEvaluation?> GetPendingEvaluationById(long evalId)
        {
            return await _context.ConcreteEvaluations.Include("Responses")
                .Include("Reviewee")
                .Include("Reviewer")
                .Where(ev => ev.Id == evalId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ConcreteEvaluation>> GetPendingEvaluationsByUsername(string username)
        {
            return await _context.ConcreteEvaluations.Where(eval => eval.Reviewer.Username == username && eval.Pending == true)
                .Include("Evaluation.EvaluationPeriodEvaluations.EvaluationPeriod").Include("Reviewer").Include("Reviewee").ToListAsync(); 
        }

        public async Task<ConcreteEvaluation?> EditConcreteEvaluation(long id, List<Response> responses)
        {
            var evaluation = await _context.ConcreteEvaluations.Where(ce => ce.Id == id)
                .Include("Responses")
                .Include("Reviewee")
                .Include("Reviewer")
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
    }
}
