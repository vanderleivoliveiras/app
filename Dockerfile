FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

COPY bin/Release/netcoreapp3.1/publish/ FCA-LoginSPD-WebAPI/
WORKDIR /FCA-LoginSPD-WebAPI
ENTRYPOINT ["dotnet", "FCA-LoginSPD-WebAPI.dll"]
