﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.DeletePatientById
{
    public sealed record class DeletePatientByIdCommand(Guid id) : IRequest<Result<string>>;
}
