
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY EmployeeManagement.Api/EmployeeManagement.Api.csproj EmployeeManagement.Api/
COPY EmployeeManagement.Application/EmployeeManagement.Application.csproj EmployeeManagement.Application/
COPY EmployeeManagement.Domain/EmployeeManagement.Domain.csproj EmployeeManagement.Domain/
COPY EmployeeManagement.Infrastructure/EmployeeManagement.Infrastructure.csproj EmployeeManagement.Infrastructure/


RUN dotnet restore EmployeeManagement.Api/EmployeeManagement.Api.csproj

COPY . .

RUN dotnet publish EmployeeManagement.Api/EmployeeManagement.Api.csproj -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "EmployeeManagement.Api.dll"]
