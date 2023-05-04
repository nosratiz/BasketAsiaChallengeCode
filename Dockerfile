FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "src/Mc2.CrudTest.Api/Mc2.CrudTest.Api.csproj"



FROM build AS publish
RUN dotnet publish "src/Mc2.CrudTest.Api/Mc2.CrudTest.Api.csproj" -c Release -o /app/publish  


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mc2.CrudTest.Api.dll"]