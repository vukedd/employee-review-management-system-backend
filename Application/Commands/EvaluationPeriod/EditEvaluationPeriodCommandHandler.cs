using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Mappers.Evaluations;
using Domain.Models.Evaluations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.EvaluationPeriod
{
    public class EditEvaluationPeriodCommandHandler : IRequestHandler<EditEvaluationPeriodCommand, Domain.Models.Evaluations.EvaluationPeriod>
    {
        private readonly IEvaluationPeriodRepository _evaluationPeriodRepository;
        public EditEvaluationPeriodCommandHandler(IEvaluationPeriodRepository evaluationPeriodRepository)
        {
            _evaluationPeriodRepository = evaluationPeriodRepository;
        }

        public async Task<Domain.Models.Evaluations.EvaluationPeriod> Handle(EditEvaluationPeriodCommand request, CancellationToken cancellationToken)
        {
            var editedProduct = await _evaluationPeriodRepository.EditEvaluationPeriodById(request.Id, request.ToDomainEntity());

            if (editedProduct == null)
                throw new NotFoundException($"An evalution period with the id: {request.Id} hasn't been found!");

            return editedProduct;
        }
    }
    public record EditEvaluationPeriodCommand(long Id, DateOnly StartDate, DateOnly EndDate, string Name, string Description) : IRequest<Domain.Models.Evaluations.EvaluationPeriod>;
}
