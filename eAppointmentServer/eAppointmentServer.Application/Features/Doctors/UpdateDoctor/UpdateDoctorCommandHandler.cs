using AutoMapper;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.UpdateDoctor
{
    public sealed class UpdateDoctorCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateDoctorCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            Doctor? doctor = await doctorRepository.GetByExpressionAsync(x => x.Id == request.id, cancellationToken);

            if (doctor == null) return Result<string>.Failure("Doctor is not found");

            mapper.Map(request, doctor);

            doctorRepository.Update(doctor);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Doctor Updated";

        }
    }
}
