#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/azure-functions/dotnet:3.0 AS base
WORKDIR /home/site/wwwroot
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["FnPerson.csproj", ""]
COPY ["NuGet.config", ""]
RUN ls

RUN dotnet restore "./FnPerson.csproj"
COPY . .
#WORKDIR "/src/."
RUN ls
RUN dotnet build "FnPerson.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FnPerson.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /home/site/wwwroot
COPY --from=publish /app/publish .
ENV KeyvaultSecretRoleRel="RolesRelationShipDBConnection"
ENV KeyvaultSecretPar="PartyDBConnection"
ENV KeyvaultSecretConPla="ContactPlaceDbConnection"
ENV KeyvaultSecretReg="Registration"
ENV KeyvaultSecretAgr="AgreementDBConnection"
ENV APPINSIGHTS_INSTRUMENTATIONKEY="6bb9e699-5003-4df2-9aed-51e2e73171a9"
ENV AzureWebJobsStorage ="DefaultEndpointsProtocol=https;AccountName=fncontactplacestorage;AccountKey=UBBiB9Satq5iXTBhpigcM3HWy2fsEX7X82msZLjsKEoPuN1pr++H2lUsIse6tvM8R/yrrhD0rHFZ+f1tqzNwUg==;EndpointSuffix=core.windows.net"
ENV KeyvaultUri="https://oneplatformdbkeyvault.vault.azure.net/"
ENV AZURE_CLIENT_ID="e34dba78-2226-4ce8-89f5-19afb8d1758f"
ENV AZURE_TENANT_ID="8db3ceb8-7446-48bc-8bb4-97803c527a37"
ENV AZURE_CLIENT_PWD="iPXaB2glmwYYvqQsB9eSQF~6i-l0jDnmaP"
ENV AgreementMsURL="http://10.200.113.143:32391/api/Agreement"
ENV ContactAndPlaceMSURL="http://10.200.113.143:31579/api/PersonContactAndPlace"
ENV PartyRoleinAgreementTypeCodeId="1"
ENV Version="1"
ENV StatusCodeListId="1"
ENV StatusReasonCodeListId="1"
ENV TextQualificationCodeListId="1"
ENV AgreementKindCodeListId="1"
ENV PartyRoleInProductTypeCodeId="1"
ENV PMPartyRoleinAgreementTypeCode="PRINCIPLE"
ENV CPPartyRoleinAgreementTypeCode="PMPROXY"
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true