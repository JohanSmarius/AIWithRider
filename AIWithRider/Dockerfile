FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AIWithRider/AIWithRider.csproj", "AIWithRider/"]
RUN dotnet restore "AIWithRider/AIWithRider.csproj"
COPY . .
WORKDIR "/src/AIWithRider"
RUN dotnet build "AIWithRider.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AIWithRider.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AIWithRider.dll"]
