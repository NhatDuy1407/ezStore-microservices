FROM microsoft/dotnet:2.1.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1.2-sdk AS build
WORKDIR /src
COPY Microservice.IdentityServer/Microservice.IdentityServer.csproj Microservice.IdentityServer/
COPY Microservice.Member.Infrastructure/Microservice.Member.Infrastructure.csproj Microservice.Member.Infrastructure/
COPY Microservice.Core/Microservice.Core.csproj Microservice.Core/
COPY Microservice.Core.DataAccess/Microservice.Core.DataAccess.csproj Microservice.Core.DataAccess/
COPY Microservice.Core.DataAccess.MongoDB/Microservice.Core.DataAccess.MongoDB.csproj Microservice.Core.DataAccess.MongoDB/
COPY Microservice.Member.Domain/Microservice.Member.Domain.csproj Microservice.Member.Domain/
RUN dotnet restore Microservice.IdentityServer/Microservice.IdentityServer.csproj
COPY . .
WORKDIR /src/Microservice.IdentityServer
RUN dotnet build Microservice.IdentityServer.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservice.IdentityServer.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservice.IdentityServer.dll"]
