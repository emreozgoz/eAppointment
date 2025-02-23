using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.CreateAppointment
{
    public sealed record class CreateAppointmentCommand(
        string startDate,
        string endDate,
        Guid doctorId,
        Guid? patientId,
        string firstName,
        string lastName,
        string IdentityNumber,
        string city,
        string town,
        string fullAddress) : IRequest<Result<string>>;
}
