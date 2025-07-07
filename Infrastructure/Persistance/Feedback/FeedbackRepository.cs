using Application.Common.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Feedback
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _context;

        public FeedbackRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Feedbacks.Feedback> CreateFeedbackAsync(Domain.Models.Feedbacks.Feedback feedback)
        {
            var addedFeedback = await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();

            return addedFeedback.Entity;
        }

        public async Task<IEnumerable<Domain.Models.Feedbacks.Feedback>> GetFeedbacksByUsername(string username)
        {
            var feedbacks = await _context.Feedbacks.Where(f => f.Reviewee.Username == username).Include("Reviewee").Include("Reviewer").ToListAsync();
            return feedbacks;
        }

        public async Task<Domain.Models.Feedbacks.Feedback?> GetLatestFeedbackAsyncByUsername(string username)
        {
            return await _context.Feedbacks.Where(f => f.Reviewee.Username == username).Include("Reviewee").Include("Reviewer").FirstOrDefaultAsync();
        }
    }
}
