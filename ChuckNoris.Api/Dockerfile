FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5012

ENV ASPNETCORE_URLS=http://+:5012

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["ChuckNoris.Api/ChuckNoris.Api.csproj", "ChuckNoris.Api/"]
RUN dotnet restore "ChuckNoris.Api/ChuckNoris.Api.csproj"
COPY . .
WORKDIR "/src/ChuckNoris.Api"
RUN dotnet build "ChuckNoris.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "ChuckNoris.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChuckNoris.Api.dll"]
