FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["IOTTasks/IOTTasks.csproj", "IOTTasks/"]
COPY ["IOT.Repositories/IOT.Repositories.csproj", "IOT.Repositories/"]
COPY ["IOT.Models/IOT.Models.csproj", "IOT.Models/"]
COPY ["IOT.Utilities/IOT.Utilities.csproj", "IOT.Utilities/"]
COPY ["IOT.Services/IOT.Services.csproj", "IOT.Services/"]
RUN dotnet restore "IOTTasks/IOTTasks.csproj"
COPY . .
WORKDIR "/src/IOTTasks"
RUN dotnet build "IOTTasks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IOTTasks.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IOTTasks.dll"]