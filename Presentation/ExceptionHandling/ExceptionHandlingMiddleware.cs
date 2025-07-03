using Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Storage;

namespace Presentation.ExceptionHandling
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext _context, RequestDelegate _next)
        {
            try
            {
                await _next(_context);
            }
            catch (Exception e)
            {
                _context.Response.ContentType = "application/json";

                var (statusCode, response) = e switch
                {
                    NotFoundException => (404, new { error = e.Message }),
                    ConflictException => (409, new { error = e.Message }),
                    UnauthorizedException => (401, new {error = e.Message}),
                    UnprocessableException => (422, new {error = e.Message}),
                    ForbiddenException => (403, new { error = e.Message}),
                    _ => (500, new { error = "An unexpected error has occurred please try again later!" }),
                };

                _context.Response.StatusCode = statusCode;
                await _context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
