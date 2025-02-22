﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.CreatePatient
{
    public sealed record class CreatePatientCommand(string firstName, string lastName, string identityNumber, string City, string Town, string fullAddress) : IRequest<Result<string>>;
}
