#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Product/Product.Api/Product.Api.csproj", "Services/Product/Product.Api/"]
COPY ["Services/Product/Product.Application/Product.Application.csproj", "Services/Product/Product.Application/"]
COPY ["Services/Product/Product.Core/Product.Core.csproj", "Services/Product/Product.Core/"]
COPY ["Services/Product/Product.Infrastructure/Product.Infrastructure.csproj", "Services/Product/Product.Infrastructure/"]
RUN dotnet restore "Services/Product/Product.Api/Product.Api.csproj"
COPY . .
WORKDIR "/src/Services/Product/Product.Api"
RUN dotnet build "Product.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Product.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Product.Api.dll"]