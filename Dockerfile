FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY ./Thyrsoft.Photobooth.WebApi/bin/Debug/net6.0 App/
WORKDIR /App
ENTRYPOINT ["dotnet", "moonbaboon.bingo.WebApi.dll"]