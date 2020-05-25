#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["demoSqlSaveJson/demoSqlSaveJson.csproj", "demoSqlSaveJson/"]
RUN dotnet restore "demoSqlSaveJson/demoSqlSaveJson.csproj"
COPY . .
WORKDIR "/src/demoSqlSaveJson"
RUN dotnet build "demoSqlSaveJson.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "demoSqlSaveJson.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "demoSqlSaveJson.dll"]