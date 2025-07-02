using Domain.Models.Evaluations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services
{
    public interface IEvaluationPeriodService
    {
        public Task<EvaluationPeriod> CreateEvaluationPeriodAsync(EvaluationPeriod evaluationPeriod);
    }
}
