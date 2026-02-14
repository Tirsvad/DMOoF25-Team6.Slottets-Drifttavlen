
# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM tirsvad/tirsvadcli_debian13_nginx AS base
#USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM base AS build
SHELL ["/bin/bash"]
ARG BUILD_CONFIGURATION=Release
RUN ["apt-get", "update"]
RUN ["apt-get", "install", "-y", "aspnetcore-runtime-8.0" ]
WORKDIR /src
COPY Slottet.CareManagement.slnx ./
COPY Directory.Build.props ./
COPY Directory.Build.targets ./
COPY Directory.Packages.props ./
COPY src/ ./src/
RUN ["dotnet", "restore"]
RUN ["dotnet", "build", "-c", "Release" ]

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
#RUN ["dotnet", "publish", "-c", "$BUILD_CONFIGURATION", "-o", "/app/publish", "/p:UseAppHost=false"]
#dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Slottet.CareManagement.dll"]
