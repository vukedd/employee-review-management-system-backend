using Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.Evaluations.EvaluationComponents
{
    public static class ResponseMapper
    {
        public static Domain.Models.Evaluations.EvaluationComponents.Response ToDomainEntity(this ResponseDto response)
        {
            return new Domain.Models.Evaluations.EvaluationComponents.Response
            {
                Id = response.Id,
                Content = response.Content,
            };
        }
    }
}
