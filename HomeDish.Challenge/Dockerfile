FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["HomeDish.Challenge/HomeDish.Challenge.csproj", "HomeDish.Challenge/"]
RUN dotnet restore "HomeDish.Challenge/HomeDish.Challenge.csproj"
COPY . .
WORKDIR "/src/HomeDish.Challenge"
RUN dotnet build "HomeDish.Challenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeDish.Challenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeDish.Challenge.dll"]