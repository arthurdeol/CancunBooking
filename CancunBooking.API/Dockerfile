#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used for VS debugging on Docker
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
ENV ASPNETCORE_URLS=https://+:5001;http://+:5000
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
RUN curl -sL https://deb.nodesource.com/setup_12.x | bash -
RUN apt install -y nodejs
WORKDIR /src
COPY ["CancunBooking.API/CancunBooking.API.csproj", "CancunBooking.API/"]
COPY ["CancunBooking.Application/CancunBooking.Application.csproj", "CancunBooking.Application/"]
COPY ["CancunBooking.Domain/CancunBooking.Domain.csproj", "CancunBooking.Domain/"]
COPY ["CancunBooking.Infrastructure/CancunBooking.Infrastructure.csproj", "CancunBooking.Infrastructure/"]
RUN dotnet restore "CancunBooking.API/CancunBooking.API.csproj"
COPY . .
WORKDIR "/src/CancunBooking.API"
RUN dotnet build "CancunBooking.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CancunBooking.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CancunBooking.API.dll"]