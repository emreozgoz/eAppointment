using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointment.DeleteAppointmentById
{
    internal sealed class DeleteAppointmentByIdCommandHandler(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteAppointmentByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteAppointmentByIdCommand request, CancellationToken cancellationToken)
        {
            eAppointmentServer.Domain.Entities.Appointment appointment = await appointmentRepository.GetByExpressionAsync(x => x.Id == request.Id, cancellationToken);
            if (appointment == null)
            {
                return Result<string>.Failure("Appointment is not found");
            }
            if (appointment.IsCompleted)
            {
                return Result<string>.Failure("You can not delete completed appointment");
            }
            appointmentRepository.Delete(appointment);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Appointment delete is succesfull";
        }
    }
}
