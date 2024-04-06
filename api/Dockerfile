# Use the official Microsoft .NET Core SDK 8 image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory to the root of the project
WORKDIR /app

# Copy the project files to the container
COPY . .

# Restore the dependencies
RUN dotnet restore

# Build the project
RUN dotnet build --configuration Release

# Publish the project
RUN dotnet publish -c Release -o out

# Use the official Microsoft .NET Core runtime image as the base image for the production environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Set the working directory to the root of the project
WORKDIR /app

# Copy the published project files to the container
COPY --from=build /app/out .

# Set the environment variables
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:80

# Expose the port that the application will listen on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "api.dll"]