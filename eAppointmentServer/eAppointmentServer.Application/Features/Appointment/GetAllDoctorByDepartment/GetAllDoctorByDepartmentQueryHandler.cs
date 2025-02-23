using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.GetAllDoctorByDepartmentQuery
{
    public sealed class GetAllDoctorByDepartmentQueryHandler(IDoctorRepository doctorRepository) : IRequestHandler<GetAllDoctorByDepartmentQuery, Result<List<Doctor>>>
    {
        async Task<Result<List<Doctor>>> IRequestHandler<GetAllDoctorByDepartmentQuery, Result<List<Doctor>>>.Handle(GetAllDoctorByDepartmentQuery request, CancellationToken cancellationToken)
        {
            List<Doctor> doctors = await doctorRepository
                .Where(x => x.Department == request.departmentValue)
                .OrderBy(x => x.FirstName)
                .ToListAsync(cancellationToken);
            return doctors;
        }
    }
}
