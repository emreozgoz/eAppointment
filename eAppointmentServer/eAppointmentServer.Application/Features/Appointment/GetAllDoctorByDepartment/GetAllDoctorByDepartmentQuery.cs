using eAppointmentServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.GetAllDoctorByDepartmentQuery
{
    public sealed record class GetAllDoctorByDepartmentQuery(int departmentValue) : IRequest<Result<List<Doctor>>>;
}
