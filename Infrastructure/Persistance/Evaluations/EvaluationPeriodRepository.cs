using Application.Common.Repositories;
using Domain.Models.Evaluations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public async Task<EvaluationPeriod?> GetEvaluationPeriodById(long evaluationPeriodId)
        {
            return await _context.EvaluationsPeriods.Where(ep => ep.Id == evaluationPeriodId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EvaluationPeriod>> GetAllEvaluationPeriods()
        {
            return await _context.EvaluationsPeriods.Select(ep => ep).ToListAsync();
        }

        public async Task<EvaluationPeriod?> DeleteEvaluationPeriodById(long evaluationPeriodId)
        {
            var evaluationPeriodForDeletion = await _context.EvaluationsPeriods.Where(ep => ep.Id == evaluationPeriodId).FirstOrDefaultAsync();

            if (evaluationPeriodForDeletion != null)
            {
                _context.Remove(evaluationPeriodForDeletion);
                await _context.SaveChangesAsync();
            }

            return evaluationPeriodForDeletion;
        }

        public async Task<EvaluationPeriod?> EditEvaluationPeriodById(long evaluationPeriodId, EvaluationPeriod evaluationPeriod)
        {
            var evaluationPeriodForEdit = await _context.EvaluationsPeriods.Where(ep => ep.Id == evaluationPeriodId).FirstOrDefaultAsync();
            if (evaluationPeriodForEdit != null)
            {
                evaluationPeriodForEdit.StartDate = evaluationPeriod.StartDate;
                evaluationPeriodForEdit.EndDate = evaluationPeriod.EndDate;
                evaluationPeriodForEdit.Name = evaluationPeriod.Name;
                evaluationPeriod.Description = evaluationPeriod.Description;
                await _context.SaveChangesAsync();
            }

            return evaluationPeriodForEdit;
        }
    }
}
