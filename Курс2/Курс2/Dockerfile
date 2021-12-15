FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Курс2/Курс2.csproj", "Курс2/"]
RUN dotnet restore "Курс2/Курс2.csproj"
COPY . .
WORKDIR "/src/Курс2"
RUN dotnet build "Курс2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Курс2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Курс2.dll"]
