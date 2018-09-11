# A microservices system built on .NET Core

## Technologies and frameworks used:
- ASP.NET MVC Core 2.1.1
- Microsoft.EntityFrameworkCore (2.1.1)
- Microsoft.AspNetCore.Identity (2.1.2)
- IdentityServer4 (2.1.1)
- mysql (5.7)
- mongo (4.1.1)
- rabbitmq (3.7)
- Docker-ce (version 18.06.1-ce, build e68fc7a)
- Kubenetes (1.10.3)
- DDD

## IDE
- Visual Studio Community 15.8.1
- Visual Studio Code

## Local Development
- First run `docker-compose -f docker-compose.init.yml up` to start databases and queues
- Wait for databases and queues ready
- Run application from Visual Studio.

## Local Kubenetes Deployment 
- First run `k8s\build-db.bat`, this will build images for databases and queues then push to Docker repository (optional: if images are already there)
- Deploy databases and queue to Kubenetes by running `k8s\deploy-db.bat`
- Run `k8s\build-api.bat` to build and publish API image
- Deploy API to Kubenetes by running `k8s\deploy-api.bat`

## Microservices
- Identity Server
- Logging Service
- Notification Service
- Product Store