#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . . 
CMD dir
COPY ["Stores.Api/Stores.Api.csproj", "Stores.Api/"]
COPY ["Stores.Domain/Stores.Domain.csproj", "Stores.Domain/"]
COPY ["Stores.Persistence/Stores.Persistence.csproj", "Stores.Persistence/"]
COPY ["Stores.Seeding/Stores.Seeding.csproj", "Stores.Seeding/"]
RUN dotnet restore "Stores.Api/Stores.Api.csproj"
COPY . .
WORKDIR "/src/Stores.Api"
RUN dotnet build "Stores.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Stores.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Stores.Api.dll"]