#get base SDK Image from Microsoft ##LINE 2: So that the Docker Engine can compile our app, we grab the .NET SDK from Microsoft*. LINE 3: We specify a dedicated “working directory” where our app will eventually reside
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

#Copy the CSPROJ file and restore any dependencies (via NUGET). ##LINE 6: We copy the .csproj file from our PC to the working container directory (/app) ## LINE 7: Using dotnet restore we resolve any project dependencies (this is done using the .csproj file and retrieving any additional dependencies via Nuget)
COPY *.csproj ./
RUN dotnet restore

#Copy the project files and build our release ##LINE 10: We copy the rest of our project files into our working directory, so we can build the app. ##Line 11: We run the dotnet publish command, specifying that it is a Release build, (-c Release), as well as specifying a folder, (out), to contain the app build dll and any support files & libraries.
COPY . ./
RUN dotnet publish -c release -o out

#Generate runtime image ##Line 14: To keep our image “lean” we retrieve only the  aspnet run time image, (as opposed t the full SDK image we used for building), as this is all our app requires to “run”.
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Docker.Les.Admin.API.dll"]

##Line 15: Re-specify our working directory
##Line 16: We expose the port we want to use from inside our app
##Line 17: Copy the relevant files from both the dependency resolution step, (build-env), and build step, (/app/out), to our working directory /app
##Line 18: Set the entry point for the app, (i.e. what should start), in this case it’s our published .dll using “dotnet”.
## Copied from : https://dotnetplaybook.com/deploy-a-net-core-api-with-docker/