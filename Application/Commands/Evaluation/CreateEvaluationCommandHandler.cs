using Application.Common.DTOs;
using Application.Common.Repositories;
using Application.Mappers.Evaluations;
using Domain.Enums.Evaluation;
using Domain.Models.Evaluations;
using Domain.Models.Evaluations.EvaluationComponents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Evaluation
{
    public class CreateEvaluationCommandHandler : IRequestHandler<CreateEvaluationCommand, Domain.Models.Evaluations.Evaluation>
    {
        private readonly IEvaluationRepository _evaluationRepository;
        public CreateEvaluationCommandHandler(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }
        public async Task<Domain.Models.Evaluations.Evaluation> Handle(CreateEvaluationCommand request, CancellationToken cancellationToken)
        {
            var createdEvaluation = await _evaluationRepository.CreateEvaluationAsync(request.ToDomainEntity());
            return createdEvaluation;
        }
    }

    public record CreateEvaluationCommand(EvaluationType type, IEnumerable<QuestionDto> questions) : IRequest<Domain.Models.Evaluations.Evaluation>;
}
