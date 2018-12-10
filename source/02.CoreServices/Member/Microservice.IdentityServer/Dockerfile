FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY 02.CoreServices/Member/Microservice.IdentityServer/Microservice.IdentityServer.csproj 02.CoreServices/Member/Microservice.IdentityServer/
COPY 01.Libraries/Microservice.Core.DomainService/Microservice.Core.DomainService.csproj 01.Libraries/Microservice.Core.DomainService/
COPY 01.Libraries/Microservice.Core/Microservice.Core.csproj 01.Libraries/Microservice.Core/
COPY 01.Libraries/Microservice.Core.Logging/Microservice.Core.Logging.csproj 01.Libraries/Microservice.Core.Logging/
COPY 02.CoreServices/Microservice.SharedEvents/Microservice.SharedEvents.csproj 02.CoreServices/Microservice.SharedEvents/
COPY 01.Libraries/Microservice.Core.DataAccess.MongoDB/Microservice.Core.DataAccess.MongoDB.csproj 01.Libraries/Microservice.Core.DataAccess.MongoDB/
COPY 01.Libraries/Microservice.Core.DataAccess/Microservice.Core.DataAccess.csproj 01.Libraries/Microservice.Core.DataAccess/
COPY 02.CoreServices/Member/Microservice.Member.Domain/Microservice.Member.Domain.csproj 02.CoreServices/Member/Microservice.Member.Domain/
COPY 02.CoreServices/Member/Microservice.Member.Infrastructure/Microservice.Member.Infrastructure.csproj 02.CoreServices/Member/Microservice.Member.Infrastructure/
RUN dotnet restore 02.CoreServices/Member/Microservice.IdentityServer/Microservice.IdentityServer.csproj
COPY . .
WORKDIR /src/02.CoreServices/Member/Microservice.IdentityServer
RUN dotnet build Microservice.IdentityServer.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservice.IdentityServer.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservice.IdentityServer.dll"]
