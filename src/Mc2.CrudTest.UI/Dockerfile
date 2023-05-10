FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore "Mc2.CrudTest.UI.csproj"
COPY . .


FROM build AS publish
RUN dotnet publish "Mc2.CrudTest.UI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Mc2.CrudTest.UI.dll"]