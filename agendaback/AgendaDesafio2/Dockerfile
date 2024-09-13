#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AgendaDesafio2.csproj", "."]
RUN dotnet restore "AgendaDesafio2.csproj"
COPY . .
RUN dotnet build "AgendaDesafio2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AgendaDesafio2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgendaDesafio2.dll"]