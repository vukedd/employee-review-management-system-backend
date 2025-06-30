using Application.Common.Repositories;
using Domain.Models.Evaluations;
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
    }
}
