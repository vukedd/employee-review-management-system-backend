using Presentation.Contracts.Request;

namespace Presentation.Mappers.Response
{
    public static class ResponseMapper
    {
        public static ResponseDto ToResponseDto(this Domain.Models.Evaluations.EvaluationComponents.Response response)
        {
            return new ResponseDto
            {
                Id = response.Id,
                Type = response.Type,
                Content = response.Content
            };
        }
    }
}
