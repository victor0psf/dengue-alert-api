# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia os arquivos do projeto
COPY . .

# Restaura e compila o projeto
RUN dotnet restore "AlertDengueApi.csproj"
RUN dotnet publish "AlertDengueApi.csproj" -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copia o resultado do build
COPY --from=build /app/publish .

# Expõe a porta padrão do ASP.NET
EXPOSE 8080

# Define o ponto de entrada
ENTRYPOINT ["dotnet", "AlertDengueApi.dll"]
