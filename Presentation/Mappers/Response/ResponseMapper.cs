using Presentation.Contracts.Request.Response;

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

        public static Application.Common.DTOs.ResponseDto ToAppResponseDto(this Presentation.Contracts.Request.Response.ResponseDto response)
        {
            return new Application.Common.DTOs.ResponseDto
            {
                Id = response.Id,
                Content = response.Content,
                Type = response.Type,
            };
        }

        public static Presentation.Contracts.Request.Response.ResponseDto ToPresResponseDto(this Domain.Models.Evaluations.EvaluationComponents.Response response)
        {
            return new Presentation.Contracts.Request.Response.ResponseDto
            {
                Id = response.Id,
                Content = response.Content,
                Type = response.Type,
            };
        }
    }
}
