using Microservice.Core.DataAccess.Entities;
using Microservice.Core.Models;
using System;

namespace Microservice.Setting.Domain.Dtos
{
    public class CountryDto: ModelStringIdEntity
    {
        public string Name { get; internal set; }
    }
}
