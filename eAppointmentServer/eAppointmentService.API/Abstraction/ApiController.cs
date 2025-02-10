using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAppointmentService.API.Abstraction
{
    public abstract class ApiController : ControllerBase
    {
        public readonly IMediator _mediator;
        protected ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
