#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microservices/MapService/MapService.csproj", "Microservices/MapService/"]
RUN dotnet restore "Microservices/MapService/MapService.csproj"
COPY . .
WORKDIR "/src/Microservices/MapService"
RUN dotnet build "MapService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MapService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MapService.dll"]