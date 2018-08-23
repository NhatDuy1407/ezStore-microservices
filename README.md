# A microservices system built on .NET Core

## Technologies and frameworks used:
- ASP.NET MVC Core 2.1.1
- Microsoft.EntityFrameworkCore (2.1.1)
- Microsoft.AspNetCore.Identity (2.1.2)
- IdentityServer4 (2.1.1)
- mysql (5.7)
- mongo (4.1.1)
- rabbitmq (3.7)

## Docker
- First run the database, message queue: `docker-compose -f docker-compose-init.yml up`
- Then run the app from Visual Studio 2017

## Microservices
- Logging Service
- Notification Service
- Identity Server