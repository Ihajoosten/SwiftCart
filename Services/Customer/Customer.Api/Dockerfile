#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Customer/Customer.Api/Customer.Api.csproj", "Services/Customer/Customer.Api/"]
RUN dotnet restore "Services/Customer/Customer.Api/Customer.Api.csproj"
COPY . .
WORKDIR "/src/Services/Customer/Customer.Api"
RUN dotnet build "Customer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customer.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.Api.dll"]