FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY ./src src/
COPY *.sln .

RUN dotnet restore

WORKDIR /app/src/Flights.Api

RUN dotnet publish -c release -o /app/published --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_HTTP_PORTS=80

WORKDIR /app
COPY --from=build /app/published ./published
ENTRYPOINT [ "dotnet", "./published/Flights.Api.dll" ]