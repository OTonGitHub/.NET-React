# Make File Executeable Using `chmod +x OT-ProjectSetup.sh"
# Run File Using `./OT-ProjectSetup.sh`

#!/usr/bin/env bash
green="\033[1;32m"
reset="\033[m"

echo "Creating Main Project Directory"
echo -e "${green}Skipped Creating Directory, Building in Current Directory${reset}"
# mkdir Reactivities
# cd Reactivities

echo -e "${green}Adding Git Ignore File${reset}"
dotnet new gitignore

echo -e "${green}Creating Solution & Projects${reset}"
dotnet new sln
dotnet new webapi -n API --use-controllers
dotnet new classlib -n Application
dotnet new classlib -n Domain
dotnet new classlib -n Persistence

echo -e "${green}Adding Projects To The Solution${reset}"
dotnet sln add API/API.csproj
dotnet sln add Application/Application.csproj
dotnet sln add Domain/Domain.csproj
dotnet sln add Persistence/Persistence.csproj

echo -e "${green}Setting Up Project Dependancies${reset}"
dotnet add API/API.csproj reference Application/Application.csproj
dotnet add Application/Application.csproj reference Domain/Domain.csproj
dotnet add Application/Application.csproj reference Persistence/Persistence.csproj
dotnet add Persistence/Persistence.csproj reference Domain/Domain.csproj

echo -e "${green}Executing Restore${reset}"
dotnet restore

echo -e "${green}FINISHED! (Listing Solution Linked Projects)${reset}"
dotnet sln list