using eAppointmentServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.UpdateAppointment
{
    public sealed record class UpdateAppointmentCommand(Guid Id, string startDate, string endDate) : IRequest<Result<string>>;
}
