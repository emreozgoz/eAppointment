using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.GetAllPatient
{
    internal class GetAllPatientQueryHandler(IPatientRepository patientRepository) : IRequestHandler<GetAllPatientQuery, Result<List<Patient>>>
    {
        public async Task<Result<List<Patient>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            List<Patient> patients = await patientRepository.GetAll().OrderBy(x => x.FirstName).ToListAsync(cancellationToken);
            return patients;
        }
    }
}
