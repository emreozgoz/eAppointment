using eAppointmentServer.Application.Features.Doctors.CreateDoctor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.UpdateDoctor
{
    public sealed record class UpdateDoctorCommand(Guid id, string firstName, string Lastname, int departmentValue) : IRequest<Result<string>>;
}
