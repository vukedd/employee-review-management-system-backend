using Domain.Enums.Feedback;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Feedbacks
{
    public class Feedback
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public Visibility Visibility { get; set; }
        public long ReviewerId { get; set; }
        public long RevieweeId { get; set; }
        public User? Reviewer { get; set; }
        public User? Reviewee { get; set; }

    }
}
