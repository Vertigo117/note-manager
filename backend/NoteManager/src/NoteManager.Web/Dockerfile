FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/NoteManager.Web/NoteManager.Web.csproj", "NoteManager.Web/"]
RUN dotnet restore "src/NoteManager.Web/NoteManager.Web.csproj"
COPY . .
WORKDIR "/src/NoteManager.Web"
RUN dotnet build "NoteManager.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NoteManager.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NoteManager.Web.dll"]
