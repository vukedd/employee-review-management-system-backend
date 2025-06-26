using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ConcreteEvaluation
    {
        public long Id { get; set; }
        public DateTime? SubmissionTime { get; set; }
        public bool IsPending { get; set; }
        public List<Response> Responses { get; set; }
        public User? Reviewer { get; set; }
        public long ReviewerId { get; set; }
        public User? Reviewee { get; set; }
        public long RevieweeId { get; set; }

        // test
        public ConcreteEvaluation(DateTime submissionTime, bool isPending, List<Response> responses, long reviewerId, long revieweeId)
        {
            this.SubmissionTime = submissionTime;
            this.IsPending = isPending;
            this.Responses = responses;
            this.ReviewerId = reviewerId;
            this.RevieweeId = revieweeId;
        }
    }
}
