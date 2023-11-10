# Этап базового образа для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Копируем файлы проекта для воспроизведения зависимостей
COPY ["Stores.Api/Stores.Api.csproj", "Stores.Api/"]
COPY ["Stores.Domain/Stores.Domain.csproj", "Stores.Domain/"]
COPY ["Stores.Persistence/Stores.Persistence.csproj", "Stores.Persistence/"]
COPY ["Stores.Seeding/Stores.Seeding.csproj", "Stores.Seeding/"]

# Воспроизводим зависимости
RUN dotnet restore "Stores.Api/Stores.Api.csproj"

# Копируем все остальные файлы проекта
COPY . .

# Производим сборку проекта
WORKDIR "/src/Stores.Api"
RUN dotnet build "Stores.Api.csproj" -c Release -o /app/build

# Этап публикации
FROM build AS publish
RUN dotnet publish "Stores.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Этап базового образа для запуска приложения (Windows образ)
FROM mcr.microsoft.com/dotnet/aspnet:7.0-windowsservercore-ltsc2022 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Копируем файлы из этапа публикации
COPY --from=publish /app/publish .

# Указываем точку входа
ENTRYPOINT ["dotnet", "Stores.Api.dll"]
