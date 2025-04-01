from mcr.microsoft.com/dotnet/sdk:3.1 as build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

from mcr.microsoft.com/dotnet/aspnet:3.1 
WORKDIR /app
EXPOSE 80

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "CHDepViewer.dll"]
