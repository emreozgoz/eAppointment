using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using System.Globalization;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.CreateAppointment
{
    public sealed class CreateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork, IPatientRepository patientRepository) : IRequestHandler<CreateAppointmentCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            Patient patient = new();
            if (request.patientId == null)
            {
                patient = new()
                {
                    City = request.city,
                    Town = request.town,
                    FirstName = request.firstName,
                    LastName = request.lastName,
                    FullAddress = request.fullAddress,
                    IdentityNumber = request.IdentityNumber
                };
                await patientRepository.AddAsync(patient);
            }
            // var x = DateTime.ParseExact(request.startDate, "MM.dd.yyyy HH:mm", CultureInfo.InvariantCulture);
            eAppointmentServer.Domain.Entities.Appointment appointment = new()
            {
                DoctorId = request.doctorId,
                PatientId = request.patientId ?? patient.Id,
                StartDate = DateTime.ParseExact(request.startDate, "MM.dd.yyyy HH:mm", CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact(request.endDate, "MM.dd.yyyy HH:mm", CultureInfo.InvariantCulture),
                IsCompleted = false
            };
            await appointmentRepository.AddAsync(appointment);
            await unitOfWork.SaveChangesAsync();
            return "Appointment created succesfull";
        }
    }
}
