using Application.Common.Exceptions;
using Application.Common.Repositories;
using Domain.Models.Evaluations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.EvaluationPeriod
{
    public class DeleteEvaluationPeriodCommandHandler : IRequestHandler<DeleteEvaluationPeriodCommand>
    {
        private readonly IEvaluationPeriodRepository _evaluationPeriodRepository;
        public DeleteEvaluationPeriodCommandHandler(IEvaluationPeriodRepository evaluationPeriodRepository)
        {
            _evaluationPeriodRepository = evaluationPeriodRepository;
        }



        public async Task Handle(DeleteEvaluationPeriodCommand request, CancellationToken cancellationToken)
        {
            var evaluationPeriodForDeletion = await _evaluationPeriodRepository.DeleteEvaluationPeriodById(request.evaluationPeriodId);
            
            if (evaluationPeriodForDeletion == null)
                throw new NotFoundException($"An evalution period with the id: {request.evaluationPeriodId} hasn't been found!");

            // While implementing the Delete command I've learned that when working with delete commands I don't have to return
            // anything. The idea is that if the repository doesn't find an element with a corresponding id I can return null
            // which will trigger the exception handling mechanism and return 404, but on the other hand if it becomes succesfull
            // it will not trigger an exception and the endpoint will eventually return NoContent :D
        }
    }

    public record DeleteEvaluationPeriodCommand(long evaluationPeriodId) : IRequest;
}
