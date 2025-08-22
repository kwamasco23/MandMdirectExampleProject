# Use the official .NET image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project file(s) and restore any dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining files and build the project
COPY . ./
RUN dotnet build -c Release -o /app/build

# Publish the project
RUN dotnet publish -c Release -o /app/publish

# Set the entry point (the command to run your application)
ENTRYPOINT ["dotnet", "/app/publish/MandMdirectExampleProject.dll"]

# Expose the port your app will run on (if applicable)
EXPOSE 87
