FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .

# Expose the required ports
EXPOSE 21

EXPOSE 5555

EXPOSE 5600
EXPOSE 5601
EXPOSE 5602
EXPOSE 5603
EXPOSE 5604
EXPOSE 5605
EXPOSE 5606
EXPOSE 5607
EXPOSE 5608
EXPOSE 5609
EXPOSE 5610

ENTRYPOINT ["dotnet", "FTP.dll"]