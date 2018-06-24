# dotnet publish -c Release (to create working dll's in ./bin/Release/netcoreapp2.1


FROM ubuntu:latest

RUN apt-get update
RUN apt-get install -y wget
RUN apt-get install -y gpg
RUN wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.asc.gpg
RUN mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/
RUN wget -q https://packages.microsoft.com/config/ubuntu/18.04/prod.list 
RUN mv prod.list /etc/apt/sources.list.d/microsoft-prod.list
RUN chown root:root /etc/apt/trusted.gpg.d/microsoft.asc.gpg
RUN chown root:root /etc/apt/sources.list.d/microsoft-prod.list
RUN apt-get install -y apt-transport-https
RUN apt-get update 
RUN apt-get install -y dotnet-sdk-2.1

WORKDIR /app
COPY ./bin/Release/netcoreapp2.1/publish/*.* ./
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ks-dynamic-sprite.dll

EXPOSE 5000

