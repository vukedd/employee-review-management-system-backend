using Domain.Models.Evaluations.EvaluationComponents;
using Domain.Models.Memberships;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Evaluations
{
    public class ConcreteEvaluation
    {
        public long Id { get; set; }
        public DateTime? SubmissionTimestamp { get; set; }
        public bool Pending { get; set; }
        public long? TeamId { get; set; }
        public Team? Team { get; set; }
        public long? EvaluationId { get; set; }
        public Evaluation? Evaluation { get; set; }
        public long? ReviewerId { get; set; }
        public User? Reviewer { get; set; }
        public long? RevieweeId { get; set; }
        public User? Reviewee { get; set; }
        public ICollection<Response> Responses { get; set; }

        public ConcreteEvaluation()
        {
            Responses = new List<Response>();
        }

        public ConcreteEvaluation(long? reviewerId, long? revieweeId)
        {
            ReviewerId = reviewerId;
            RevieweeId = revieweeId;
            Pending = true;
            Responses = new List<Response>();
        }
    }
}
