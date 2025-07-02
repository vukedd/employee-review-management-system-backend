using Application.Common.Repositories;
using Domain.Models.Evaluations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Evaluations
{
    public class EvaluationRepository : IEvaluationRepository
    {
        private readonly AppDbContext _context;
        public EvaluationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Evaluation> CreateEvaluationAsync(Evaluation evaluation)
        {
            var addedEvaluation = await _context.Evaluations.AddAsync(evaluation);
            await _context.SaveChangesAsync();

            return addedEvaluation.Entity;
        }

        public async Task<List<Evaluation>> GetEvaluationByEvaluationPeriodIdAsync(long evaluationPeriodId)
        {
            var evaluations = await _context.EvaluationPeriodEvaluations.Include("Evaluation").Where(epe => epe.EvaluationPeriodId == evaluationPeriodId).ToListAsync();
            return evaluations.Select(e => e.Evaluation).ToList();
        }

        public async Task<Evaluation?> GetEvaluationByIdAsync(long id)
        {
            return await _context.Evaluations.Where(e => e.Id == id).Include("Questions").FirstOrDefaultAsync();
        }
    }
}
