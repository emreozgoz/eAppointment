using eAppointmentServer.Application.Features.Patients.CreatePatient;
using eAppointmentServer.Application.Features.Patients.GetAllPatient;
using eAppointmentService.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using eAppointmentServer.Application.Features.Patients.DeletePatientById;
using eAppointmentServer.Application.Features.Patients.UpdatePatient;

namespace eAppointmentService.API.Controllers
{
    public class PatientsController : ApiController
    {
        public PatientsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllPatientQuery query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientCommand query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeletePatientByIdCommand query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePatientCommand query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
