FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Meetup/Meetup.csproj", "Meetup/"]
RUN dotnet restore "Meetup/Meetup.csproj"
COPY . .
WORKDIR "/src/Meetup"
RUN dotnet build "Meetup.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Meetup.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Meetup.dll"]