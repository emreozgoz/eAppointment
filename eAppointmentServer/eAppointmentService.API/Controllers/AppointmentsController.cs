using eAppointmentServer.Application.Features.Appointment.CreateAppointment;
using eAppointmentServer.Application.Features.Appointment.DeleteAppointmentById;
using eAppointmentServer.Application.Features.Appointment.GetAllDoctorByDepartmentQuery;
using eAppointmentServer.Application.Features.Appointment.GetPatientByIdentityNumber;
using eAppointmentServer.Application.Features.Appointment.UpdateAppointment;
using eAppointmentServer.Application.Features.Appointments.GetAllAppointments;
using eAppointmentServer.Application.Features.Doctors.GetAllDoctor;
using eAppointmentService.API.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eAppointmentService.API.Controllers
{
    public class AppointmentsController : ApiController
    {
        public AppointmentsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAllDoctorByDepartment(GetAllDoctorByDepartmentQuery query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }

        [HttpPost]
        public async Task<IActionResult> GetAllByDoctorId(GetAllAppointmentsByDoctorIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> GetPatientByIdentityNumber(GetPatientByIdentityNumberQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteAppointmentByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
