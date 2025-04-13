FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app

COPY CaseItau.API/*.csproj ./CaseItau.API/
COPY CaseItau.Application/*.csproj ./CaseItau.Application/
COPY CaseItau.Domain/*.csproj ./CaseItau.Domain/
COPY CaseItau.Infrastructure/*.csproj ./CaseItau.Infrastructure/
COPY CaseItau.Mapper/*.csproj ./CaseItau.Mapper/
COPY CaseItau.Shared/*.csproj ./CaseItau.Shared/

COPY . ./
RUN dotnet restore ./CaseItau.API/CaseItau.API.csproj

RUN dotnet publish -c Release -o out

COPY CaseItau.Infrastructure/Database.db ./out/Database.db

FROM mcr.microsoft.com/dotnet/sdk:3.1
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 5000

ENTRYPOINT ["dotnet", "CaseItau.API.dll"]
