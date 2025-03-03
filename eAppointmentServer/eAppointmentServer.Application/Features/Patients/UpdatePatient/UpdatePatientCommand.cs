﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.UpdatePatient
{
    public sealed record class UpdatePatientCommand(Guid id, string firstName, string lastName, string identityNumber, string City, string Town, string fullAddress) : IRequest<Result<string>>;
}
