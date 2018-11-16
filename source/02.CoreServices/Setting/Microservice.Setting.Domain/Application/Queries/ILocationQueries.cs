﻿using Microservice.Setting.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservice.Setting.Domain.Application.Queries
{
    public interface ILocationQueries
    {
        Task<CountryDto> Get(string id);

        Task<IEnumerable<CountryDto>> Get();
    }
}
