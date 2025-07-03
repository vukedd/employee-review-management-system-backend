using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Mappers.Evaluations.EvaluationComponents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ConcreteEvaluation
{
    public class SubmitEvaluationCommandHandler : IRequestHandler<SubmitEvaluationCommand, Domain.Models.Evaluations.ConcreteEvaluation>
    {
        private readonly IConcreteEvaluationRepository _concreteEvaluationRepository;
        public SubmitEvaluationCommandHandler(IConcreteEvaluationRepository concreteEvaluationRepository)
        {
            _concreteEvaluationRepository = concreteEvaluationRepository;
        }

        public async Task<Domain.Models.Evaluations.ConcreteEvaluation> Handle(SubmitEvaluationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _concreteEvaluationRepository.EditConcreteEvaluation(request.id, request.responses.Select(re => re.ToDomainEntity()).ToList());
            if (entity == null)
                throw new NotFoundException("The evaluation you are looking for hasn't been found!");

            return entity;
        }
    }

    public record SubmitEvaluationCommand(long id, IEnumerable<ResponseDto> responses) : IRequest<Domain.Models.Evaluations.ConcreteEvaluation>;
}
