using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DTOs
{
    public class StatisticsDto
    {
        public long missedEvaluations { get; set; }
        public long submittedEvaluations { get; set; }
        public long pendingEvaluations { get; set; }
        public long totalEvaluations { get; set; }
    }
}
