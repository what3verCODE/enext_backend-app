FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

ARG buildconfig=RELEASE

COPY *.sln .
COPY ApiServer/*.csproj ./ApiServer/
COPY Application/*.csproj ./Application/
COPY Domain/*.csproj ./Domain/

RUN dotnet restore

COPY ApiServer/. ./ApiServer/
COPY Application/. ./Application/
COPY Domain/. ./Domain/
RUN dotnet build ./ApiServer -c $buildconfig -o /out --no-restore

RUN dotnet publish -c $buildconfig -o /out --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /out ./

ENTRYPOINT ["dotnet", "ApiServer.dll"]
