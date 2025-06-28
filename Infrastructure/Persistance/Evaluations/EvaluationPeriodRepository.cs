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
    public class EvaluationPeriodRepository : IEvaluationPeriodRepository
    {
        private readonly AppDbContext _context;
        public EvaluationPeriodRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EvaluationPeriod> CreateEvaluationPeriodAsync(EvaluationPeriod evaluationPeriod)
        {
            var newEvaluationPeriod = await _context.EvaluationsPeriods.AddAsync(evaluationPeriod);
            await _context.SaveChangesAsync();
            return newEvaluationPeriod.Entity;
        }

        public async Task<ICollection<EvaluationPeriod>> GetAllEvaluationPeriods()
        {
            return await _context.EvaluationsPeriods.Select(ep => ep).ToListAsync();
        }

        public async Task<EvaluationPeriod?> GetEvaluationPeriodById(long evaluationPeriodId)
        {
            return await _context.EvaluationsPeriods.Where(ep => ep.Id == evaluationPeriodId).FirstOrDefaultAsync();
        }
    }
}
