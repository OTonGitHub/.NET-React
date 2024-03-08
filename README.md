# NETReact-Server

Neil Cummings Udemy Course on building .NET and React App - Following Tutorial

### Development Environment

- Github Codespace
- VSCode

### Notes

- Run `OT-ProjectSetup.sh` - I recommend going through this script and become familiar with the commands
- run `ctrl + shift + p` then "Generate" -> .NET: Generate Assets for Build and Debug
- in launchSettings.json, launchUrl is most likely only enabled when launchBrowser is turned on.
- #### Routing
  - if no route template defined for method, eg [HttpGet("somePath")], and if url does-not match any defined routes, then default route will be undefined route.
  - the `name =  ` atribute in HttpGet() is not for route, but URL generation.
- Test Note.
- Global using property, grabs using from aut-generated file in -> `obj/Debug/net8.0/API.GlobalUsings.g.cs`

### Commands

- Run startup project `dotnet run --project API`
