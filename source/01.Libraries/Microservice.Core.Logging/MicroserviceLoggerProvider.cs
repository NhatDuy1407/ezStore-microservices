﻿using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Microservice.Core.Logging
{
    public class MicroserviceLoggerProvider : ILoggerProvider
    {
        private readonly IBusControl _busControl;
        private readonly IConfiguration Configuration;

        public MicroserviceLoggerProvider(IBusControl busControl, IConfiguration configuration)
        {
            _busControl = busControl;
            Configuration = configuration;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new MicroserviceLogging(categoryName, Configuration, _busControl);
        }

        public void Dispose()
        {
        }
    }
}
