# Use the official .NET SDK image to build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files
COPY *.sln .
COPY Backend/*.csproj ./Backend/
COPY Backend.Tests/*.csproj ./Backend.Tests/
RUN dotnet restore

# Copy the rest of the code
COPY Backend/. ./Backend/
COPY Backend.Tests/. ./Backend.Tests/

# Run tests
RUN dotnet test --no-restore

# Build the application
WORKDIR /src/Backend
RUN dotnet publish -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "danish-notebook-llm.dll"] 