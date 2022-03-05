# escape=`

# This is an example Dockerfile for an ASP.NET Core Rendering Host.
# We use build stages to enable 'dotnet watch' during development, so
# that changes to your rendering code can be quickly tested, including in
# the Experience Editor. Be sure to watch the container logs in case of build errors.

ARG DEBUG_PARENT_IMAGE
ARG RELEASE_PARENT_IMAGE
ARG SOLUTION_IMAGE

FROM ${DEBUG_PARENT_IMAGE} as debug
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]
WORKDIR /solution/src
ENV DOTNET_WATCH_SUPPRESS_LAUNCH_BROWSER=true
EXPOSE 80
ENTRYPOINT ["dotnet", "watch", "-v", "--project", "Project\\Hackathon\\rendering\\Hackathon.Project.Website.Rendering.csproj", "run", "--no-launch-profile"]

FROM ${SOLUTION_IMAGE} as solution
FROM ${RELEASE_PARENT_IMAGE} as release
WORKDIR /app
COPY --from=solution /artifacts/rendering/ ./
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "Hackathon.Project.Website.Rendering.dll"]