using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services
{
    public interface IMailService
    {
        Task SendVerificationEmail(string to, string token);
        Task EvaluationCycleEmail(string to, string evaluationName, DateOnly? startDate, DateOnly? endDate);
    }
}
