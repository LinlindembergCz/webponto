#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["WebPonto/WebPonto.API/WebPonto.API.csproj", "WebPonto/WebPonto.API/"]
COPY ["WebPonto/WebPonto.Infra.CrossCutting.IoC/WebPonto.Infra.CrossCutting.IoC.csproj", "WebPonto/WebPonto.Infra.CrossCutting.IoC/"]
COPY ["WebPonto/WebPonto.Infra.Data/WebPonto.Infra.Data.csproj", "WebPonto/WebPonto.Infra.Data/"]
COPY ["WebPonto/WebPonto.Domain/WebPonto.Domain.csproj", "WebPonto/WebPonto.Domain/"]
COPY ["WebPonto/WebPonto.Application/WebPonto.Application.csproj", "WebPonto/WebPonto.Application/"]
RUN dotnet restore "WebPonto/WebPonto.API/WebPonto.API.csproj"
COPY . .
WORKDIR "/src/WebPonto/WebPonto.API"
RUN dotnet build "WebPonto.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebPonto.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebPonto.API.dll"]