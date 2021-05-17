FROM mcr.microsoft.com/dotnet/sdk AS build
WORKDIR /app

COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c release -o .

FROM mcr.microsoft.com/dotnet/aspnet
WORKDIR /app
COPY --from=build /app ./
ENV ASPNETCORE_HTTP_PORT=80
ENV ASPNETCORE_HTTPS_PORT=81
ENV ASPNETCORE_URLS="https://+;http://+;"
ENTRYPOINT [ "dotnet", "AluraReadingApp.dll" ]