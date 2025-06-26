using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class EvaluationPeriod
    {
        public long Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public EvaluationPeriod(DateOnly StartDate, DateOnly EndDate, string name, string description)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Name = name;
            this.Description = description;
        }

    }
}
