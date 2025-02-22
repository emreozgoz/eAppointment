using AutoMapper;
using eAppointmentServer.Application.Features.Doctors.UpdateDoctor;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.UpdatePatient
{
    internal class UpdatePatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdatePatientCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient? patient = await patientRepository.GetByExpressionAsync(x => x.Id == request.id, cancellationToken);

            if (patient == null) return Result<string>.Failure("Patient is not found");
            if (patient.IdentityNumber != request.identityNumber)
            {
                if (patientRepository.Any(x => x.IdentityNumber == request.identityNumber))
                {
                    return Result<string>.Failure("Already Using");
                }
            }
            mapper.Map(request, patient);

            patientRepository.Update(patient);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Patient Updated";
        }
    }
}
