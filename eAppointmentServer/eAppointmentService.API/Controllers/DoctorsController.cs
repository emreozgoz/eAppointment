using eAppointmentServer.Application.Features.Doctors.CreateDoctor;
using eAppointmentServer.Application.Features.Doctors.DeleteDoctorById;
using eAppointmentServer.Application.Features.Doctors.GetAllDoctor;
using eAppointmentService.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAppointmentService.API.Controllers
{
    
    public class DoctorsController : ApiController
    {
        public DoctorsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllDoctorQuery query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorCommand query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }


        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteDoctorByIdCommand query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }
    }
}
