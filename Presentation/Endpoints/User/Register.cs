using FastEndpoints;
using MediatR;
using Presentation.Contracts;
using Presentation.Contracts.Request.User;
using Presentation.Contracts.Response.User;
using Presentation.Mappers.User;

namespace Presentation.Endpoints.User
{
    public class Register : Endpoint<RegisterUserContract, RegisterUserResponse>
    {
        private readonly IMediator _mediator;
        public Register(IMediator mediator) 
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Post("register");
            AllowAnonymous();
        }

        public override async Task HandleAsync(RegisterUserContract req, CancellationToken ct)
        {
            var registeredUser = await _mediator.Send(req.ToRegisterCommand());

            await SendOkAsync(registeredUser.ToRegisterResponse());
        }
    }
}
