FROM mcr.microsoft.com/dotnet/sdk:5.0 as development
WORKDIR /app
EXPOSE 80
EXPOSE 81
ENV ASPNETCORE_URLS="https://+;http://+;"
ENV ASPNETCORE_HTTP_PORT=80
ENV ASPNETCORE_HTTPS_PORT=81
ENTRYPOINT ["dotnet", "watch", "run"]