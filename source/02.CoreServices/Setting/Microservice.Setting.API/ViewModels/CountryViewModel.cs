﻿using Microservice.Core.Models;

namespace Microservice.Setting.API.ViewModels
{
    public class CountryViewModel : ModelStringIdEntity
    {
        public string Name { get; internal set; }
    }
}