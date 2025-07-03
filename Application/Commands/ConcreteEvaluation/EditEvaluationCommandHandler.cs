using Application.Common.DTOs;
using Application.Common.Exceptions;
using Application.Common.Repositories;
using Application.Mappers.Evaluations.EvaluationComponents;
using Domain.Models.Evaluations.EvaluationComponents;
using MediatR;
using System.Runtime.Intrinsics.Arm;

namespace Application.Commands.ConcreteEvaluation
{
    public class EditEvaluationCommandHandler : IRequestHandler<EditEvaluationCommand, Domain.Models.Evaluations.ConcreteEvaluation>
    {
        private readonly IConcreteEvaluationRepository _evaluationRepository;
        public EditEvaluationCommandHandler(IConcreteEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public async Task<Domain.Models.Evaluations.ConcreteEvaluation> Handle(EditEvaluationCommand request, CancellationToken cancellationToken)
        {
            var evaluationForEdit = await _evaluationRepository.GetConcreteEvaluationById(request.Id);
            
            if (evaluationForEdit == null)
                throw new NotFoundException("The evaluation you are looking for hasn't been found!");

            var currDate = DateOnly.FromDateTime(DateTime.Now);

            if (evaluationForEdit.EvaluationPeriod.EndDate < currDate)
                throw new ForbiddenException("The deadline to submit this form has passed. You don't have the permission for this action!");

            if (evaluationForEdit.Evaluation.Type != Domain.Enums.Evaluation.EvaluationType.SELF)
                throw new ForbiddenException("Permission denied! Self evaluations can be modified by the user himself!");


            var modifiedEvaluation = await _evaluationRepository
                .EditConcreteEvaluation(request.Id, request.Responses.ToList());

            return modifiedEvaluation;
        }
    }

    public record EditEvaluationCommand(long Id, IEnumerable<Response> Responses) : IRequest<Domain.Models.Evaluations.ConcreteEvaluation>;
}
