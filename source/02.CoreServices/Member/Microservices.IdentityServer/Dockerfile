FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY 02.CoreServices/Member/Microservices.IdentityServer/Microservices.IdentityServer.csproj 02.CoreServices/Member/Microservices.IdentityServer/
COPY 01.Libraries/Microservices.Core.DomainService/Microservices.Core.DomainService.csproj 01.Libraries/Microservices.Core.DomainService/
COPY 01.Libraries/Microservices.Core/Microservices.Core.csproj 01.Libraries/Microservices.Core/
COPY 01.Libraries/Microservices.Core.Logging/Microservices.Core.Logging.csproj 01.Libraries/Microservices.Core.Logging/
COPY 02.CoreServices/Microservices.SharedEvents/Microservices.SharedEvents.csproj 02.CoreServices/Microservices.SharedEvents/
COPY 01.Libraries/Microservices.Core.DataAccess.MongoDB/Microservices.Core.DataAccess.MongoDB.csproj 01.Libraries/Microservices.Core.DataAccess.MongoDB/
COPY 01.Libraries/Microservices.Core.DataAccess/Microservices.Core.DataAccess.csproj 01.Libraries/Microservices.Core.DataAccess/
COPY 02.CoreServices/Member/Microservices.Member.Domain/Microservices.Member.Domain.csproj 02.CoreServices/Member/Microservices.Member.Domain/
COPY 02.CoreServices/Member/Microservices.Member.Infrastructure/Microservices.Member.Infrastructure.csproj 02.CoreServices/Member/Microservices.Member.Infrastructure/
RUN dotnet restore 02.CoreServices/Member/Microservices.IdentityServer/Microservices.IdentityServer.csproj
COPY . .
WORKDIR /src/02.CoreServices/Member/Microservices.IdentityServer
RUN dotnet build Microservices.IdentityServer.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Microservices.IdentityServer.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Microservices.IdentityServer.dll"]
