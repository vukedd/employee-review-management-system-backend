using Domain.Models.Feedbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Repositories
{
    public interface IFeedbackRepository
    {
        public Task<Feedback> CreateFeedbackAsync(Feedback feedback);
        public Task<Feedback?> GetLatestFeedbackAsyncByUsername(string username);
        public Task<IEnumerable<Feedback>> GetFeedbacksByUsername(string username);
    }
}
