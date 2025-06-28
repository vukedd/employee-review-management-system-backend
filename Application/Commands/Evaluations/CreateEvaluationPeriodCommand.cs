using Application.Common.Repositories;
using Application.Mappers.Evaluations;
using Domain.Models.Evaluations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Evaluations
{
    public class CreateEvaluationPeriodCommandHandler : IRequestHandler<CreateEvaluationPeriodCommand, EvaluationPeriod>
    {
        private readonly IEvaluationPeriodRepository _evaluationPeriodRepository;

        public CreateEvaluationPeriodCommandHandler(IEvaluationPeriodRepository evaluationPeriodRepository)
        {
            _evaluationPeriodRepository = evaluationPeriodRepository;
        }

        public async Task<EvaluationPeriod> Handle(CreateEvaluationPeriodCommand request, CancellationToken cancellationToken)
        {
            var domainEntity = request.ToDomainEntity();
            var persistedProduct = await _evaluationPeriodRepository.CreateEvaluationPeriodAsync(domainEntity);
            return persistedProduct;
        }
    }
    // We are using records to represent DTOs which because of their immutablity feature, since we don't want to modify
    // the request data while transfering it to the handler.
    public record CreateEvaluationPeriodCommand(DateOnly StartDate, DateOnly EndDate, string Name, string Description) : IRequest<EvaluationPeriod>;
}
