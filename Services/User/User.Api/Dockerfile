#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/User/User.Api/User.Api.csproj", "Services/User/User.Api/"]
COPY ["Services/User/User.Application/User.Application.csproj", "Services/User/User.Application/"]
COPY ["Services/User/User.Core/User.Core.csproj", "Services/User/User.Core/"]
COPY ["Services/User/User.Infrastructure/User.Infrastructure.csproj", "Services/User/User.Infrastructure/"]
RUN dotnet restore "Services/User/User.Api/User.Api.csproj"
COPY . .
WORKDIR "/src/Services/User/User.Api"
RUN dotnet build "User.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "User.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.Api.dll"]