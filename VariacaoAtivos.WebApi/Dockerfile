FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5279

ENV ASPNETCORE_URLS=http://+:5279

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VariacaoAtivos.WebApi/VariacaoAtivos.WebApi.csproj", "VariacaoAtivos.WebApi/"]
RUN dotnet restore "VariacaoAtivos.WebApi/VariacaoAtivos.WebApi.csproj"
COPY . .
WORKDIR "/src/VariacaoAtivos.WebApi"
RUN dotnet build "VariacaoAtivos.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VariacaoAtivos.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VariacaoAtivos.WebApi.dll"]
