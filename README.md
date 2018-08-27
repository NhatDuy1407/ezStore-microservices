# A microservices system built on .NET Core

## Technologies and frameworks used:
- ASP.NET MVC Core 2.1.1
- Microsoft.EntityFrameworkCore (2.1.1)
- Microsoft.AspNetCore.Identity (2.1.2)
- IdentityServer4 (2.1.1)
- mysql (5.7)
- mongo (4.1.1)
- rabbitmq (3.7)
- Docker-ce
- DDD

## IDE
- Visual studio code

## Docker
- First run the database, message queue: `docker-compose -f docker-compose-init.yml up`
- Then run the app as development by command:
  + dotnet publish .\ezStoreMicroservice.sln
  + docker-compose -f docker-compose.yml -f docker-compose.override.yml up --force-recreate

## Microservices
- Logging Service
- Notification Service
- Identity Server