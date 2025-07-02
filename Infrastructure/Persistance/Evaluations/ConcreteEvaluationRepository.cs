using Application.Common.Repositories;
using Domain.Models.Evaluations;
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
    }
}
