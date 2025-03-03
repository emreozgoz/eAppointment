﻿using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using System.Globalization;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.UpdateAppointment
{
    public sealed class UpdateAppointmentCommandHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateAppointmentCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            DateTime startDate = DateTime.ParseExact(request.startDate, "MM.dd.yyyy HH:mm", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(request.endDate, "MM.dd.yyyy HH:mm", CultureInfo.InvariantCulture);
            eAppointmentServer.Domain.Entities.Appointment appointment = await appointmentRepository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id, cancellationToken);

            if (appointment == null)
            {
                return Result<string>.Failure("Appointment is not found");
            }

            bool isAppointmentDateNotAvailable =
           await appointmentRepository
           .AnyAsync(p => p.DoctorId == appointment.DoctorId &&
            ((p.StartDate < endDate && p.StartDate >= startDate) || // Mevcut randevunun bitişi, diğer randevunun başlangıcıyla çakışıyor
            (p.EndDate > startDate && p.EndDate <= endDate) || // Mevcut randevunun başlangıcı, diğer randevunun bitişiyle çakışıyor
            (p.StartDate >= startDate && p.EndDate <= endDate) || // Mevcut randevu, diğer randevu içinde tamamen
            (p.StartDate <= startDate && p.EndDate >= endDate)), // Mevcut randevu, diğer randevuyu tamamen kapsıyor
            cancellationToken);

            if (isAppointmentDateNotAvailable)
            {
                return Result<string>.Failure("Appointment date is not available");
            }
            appointment.StartDate = DateTime.ParseExact(request.startDate, "MM.dd.yyyy HH:mm", CultureInfo.InvariantCulture);
            appointment.EndDate = DateTime.ParseExact(request.endDate, "MM.dd.yyyy HH:mm", CultureInfo.InvariantCulture);
            unitOfWork.SaveChangesAsync(cancellationToken);
            return "Appointment is succesfully updated";
        }
    }
}
