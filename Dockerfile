# escape=`
ARG BUILD_IMAGE

FROM ${BUILD_IMAGE} AS nuget-prep
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
# Gather only artifacts necessary for NuGet restore, retaining directory structure
COPY *.sln nuget.config Directory.Build.targets Packages.props /nuget/
COPY src/ /temp/
RUN Invoke-Expression 'robocopy C:/temp C:/nuget/src /s /ndl /njh /njs *.csproj *.scproj packages.config'

FROM ${BUILD_IMAGE} AS builder
ARG BUILD_CONFIGURATION

SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
# Ensure updated nuget. Depending on your Windows version, dotnet/framework/sdk:4.8 tag may provide an outdated client.
# See https://github.com/microsoft/dotnet-framework-docker/blob/1c3dd6638c6b827b81ffb13386b924f6dcdee533/4.8/sdk/windowsservercore-ltsc2019/Dockerfile#L7
ENV NUGET_VERSION 5.8.1
RUN Invoke-WebRequest "https://dist.nuget.org/win-x86-commandline/v$env:NUGET_VERSION/nuget.exe" -UseBasicParsing -OutFile "$env:ProgramFiles\NuGet\nuget.exe"
WORKDIR /build

# Copy prepped NuGet artifacts, and restore as distinct layer to take advantage of caching.
COPY --from=nuget-prep ./nuget ./

# Restore NuGet packages
RUN nuget restore -Verbosity quiet

# Copy remaining source code
COPY src/ ./src/

# Copy transforms, retaining directory structure
RUN Invoke-Expression 'robocopy /build/src /build/transforms /s /ndl /njh /njs *.xdt'

# Build the Sitecore main platform artifacts
RUN msbuild .\src\Environment\platform\Hackathon.Environment.Platform.csproj /p:Configuration=$env:BUILD_CONFIGURATION /p:DeployOnBuild=True /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:PublishUrl=/build/sitecore
RUN msbuild .\src\Environment\identity\Hackathon.Environment.Identity.csproj /p:Configuration=$env:BUILD_CONFIGURATION /p:DeployOnBuild=True /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:PublishUrl=/build/identity

# Build the rendering host
WORKDIR /build/src/Project/Hackathon/rendering/
RUN dotnet publish -c $env:BUILD_CONFIGURATION -o /build/rendering --no-restore

FROM mcr.microsoft.com/windows/nanoserver:1809
WORKDIR /artifacts
# Copy final build artifacts
COPY --from=builder /build/sitecore  ./sitecore/
COPY --from=builder /build/transforms ./transforms/
COPY --from=builder /build/rendering ./rendering/
COPY --from=builder /build/identity/Config ./identity/Config