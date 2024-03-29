#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ROH.Api.Version/ROH.Api.Version.csproj", "ROH.Api.Version/"]
COPY ["ROH.Context/ROH.Context.csproj", "ROH.Context/"]
COPY ["ROH.Domain/ROH.Domain.csproj", "ROH.Domain/"]
COPY ["ROH.Interfaces/ROH.Interfaces.csproj", "ROH.Interfaces/"]
COPY ["ROH.StandardModels/ROH.StandardModels.csproj", "ROH.StandardModels/"]
COPY ["ROH.Mapper/ROH.Mapper.csproj", "ROH.Mapper/"]
COPY ["ROH.Repository/ROH.Repository.csproj", "ROH.Repository/"]
COPY ["ROH.Services/ROH.Services.csproj", "ROH.Services/"]
COPY ["ROH.Validations/ROH.Validations.csproj", "ROH.Validations/"]
COPY ["ROH.Utils/ROH.Utils.csproj", "ROH.Utils/"]
RUN dotnet restore "./ROH.Api.Version/./ROH.Api.Version.csproj"
COPY . .
WORKDIR "/src/ROH.Api.Version"
RUN dotnet build "./ROH.Api.Version.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ROH.Api.Version.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ROH.Api.Version.dll"]