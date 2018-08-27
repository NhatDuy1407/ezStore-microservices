FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base

RUN cp bin/Debug/netcoreapp2.1/ /app
ENTRYPOINT ["dotnet", "Microservice.Logging.API.dll"]
WORKDIR /app
EXPOSE 80
