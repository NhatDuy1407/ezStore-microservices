FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base

RUN cp ./bin/Debug/netcoreapp2.1/publish/ /app
ENTRYPOINT ["dotnet", "Microservice.IdentityServer.dll"]
WORKDIR /app
EXPOSE 80
