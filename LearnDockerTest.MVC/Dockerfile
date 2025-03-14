FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY /nginx/api-cert.crt /usr/local/share/ca-certificates/api-cert.crt
RUN update-ca-certificates
EXPOSE 7092
EXPOSE 5065

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
ARG configuration=Release
WORKDIR /src
COPY ["LearnDockerTest.MVC.csproj", "."]
RUN dotnet restore "LearnDockerTest.MVC.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "LearnDockerTest.MVC.csproj" -c $configuration -o /app/build

FROM build as publish
ARG configuration=Release
RUN dotnet publish "LearnDockerTest.MVC.csproj" -c $configuration -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "LearnDockerTest.MVC.dll" ]

