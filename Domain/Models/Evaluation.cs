using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Evaluation
    {
        public long Id {  get; set; }
        public EvaluationType EvaluationType { get; set; }
        public List<Question> Questions { get; set; }

        public Evaluation(EvaluationType evaluationType, List<Question> questions)
        {
            this.Questions = questions;
            this.EvaluationType = evaluationType;
        }

    }
}
