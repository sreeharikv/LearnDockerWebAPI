FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
USER app
EXPOSE 5170
EXPOSE 7299

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["LearnDockerTest.API.csproj", "."]
RUN dotnet restore "LearnDockerTest.API.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "LearnDockerTest.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "LearnDockerTest.API.csproj" -c $configuration -o /app/publish -r linux-musl-x64

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearnDockerTest.API.dll"]
