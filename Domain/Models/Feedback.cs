using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Feedback
    {
        public long Id { get; }
        public string Content { get; set; }
        public User? Reviewer { get; set; }
        public long ReviewerId { get; set; }
        public User? Reviewee { get; set; }
        public long RevieweeId { get; set; }
        public Visibility Visibility { get; set; }

        public Feedback(string content, Visibility visibility, long reviewerId, long revieweeId)
        {
            this.Content = content;
            this.Visibility = visibility;
            this.ReviewerId = reviewerId;
            this.RevieweeId = revieweeId;
        }
    }
}
