FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MinimalOrganized.ExampleApis/MinimalOrganized.ExampleApis.csproj", "MinimalOrganized.ExampleApis/"]
RUN dotnet restore "MinimalOrganized.ExampleApis/MinimalOrganized.ExampleApis.csproj"
COPY . .
WORKDIR "/src/MinimalOrganized.ExampleApis"
RUN dotnet build "MinimalOrganized.ExampleApis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MinimalOrganized.ExampleApis.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinimalOrganized.ExampleApis.dll"]
