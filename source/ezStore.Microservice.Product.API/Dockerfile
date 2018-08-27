FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base

RUN cp bin/Debug/netcoreapp2.1/publish/ /app
ENTRYPOINT ["dotnet", "ezStore.Microservice.Product.API.dll"]
WORKDIR /app
EXPOSE 80