using AutoMapper;
using eAppointmentServer.Application.Features.Doctors.CreateDoctor;
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

namespace eAppointmentServer.Application.Features.Patients.CreatePatient
{
    internal class CreatePatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreatePatientCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            if(patientRepository.Any(x=>x.IdentityNumber == request.identityNumber))
            {
                return Result<string>.Failure("Identity Number Already Registered");
            }
            Patient patient = mapper.Map<Patient>(request);
            await patientRepository.AddAsync(patient);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Patient Created Successfully";
        }
    }
}
