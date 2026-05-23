# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DevopsDashboard.App.csproj", "./"]
RUN dotnet restore "DevopsDashboard.App.csproj"
COPY . .
RUN dotnet publish "DevopsDashboard.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=build /app/publish/wwwroot .
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
