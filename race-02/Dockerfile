#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["race-02/race-02.csproj", "race-02/"]
RUN dotnet restore "race-02/race-02.csproj"
COPY . .
WORKDIR "/src/race-02"
RUN dotnet build "race-02.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "race-02.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY race-02/file/file.bin /file/file.bin
ENTRYPOINT ["dotnet", "race-02.dll"]