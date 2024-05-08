# .NET-React

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
  - lot of conventions are used, in riot priotity, NEED MORE NOTES HERE.
- Test Note.
- Global using property, grabs using from aut-generated file in -> `obj/Debug/net8.0/API.GlobalUsings.g.cs`
- API has transitive dependency on persistene, via Application. But will need `dotnet restore` run on solution, to access packages on the other projects.
- Startup project must have nuget package `Microsoft.EntityFrameworkCore.Design` installed, in order to create migrations in that project.
- Because nullable was disabled, tables created, with string properties have nullable set to true, as default is nullable.
- Use `// <auto-generated />` on top of files to ignore static code analysis (by SonarLint)
- Fields usually get injected to class, properties are part of the object (class)
- issues in `dotnet watch` not grabbing newly added routes, shown in tutorial, but not tested in project yet, likely not to work.
- using global .gitignore because, some extension related files are created on root and applies for both .NET and React stuff. It's just easier to keep it in one place since this file won't be edited often
- `.nvmrc` file is also kept in root because all commands are meant to be run from the root, and node version is set from root of project in this case.
- decided to maybe not disable telemtry for dotnet CLI when working in a codespace, to support .NET development.

### Commands

- For commands to run for project setup, see `OT-ProjectSetup.sh`
- Run startup project `dotnet run --project API`
- `dotnet add /workspaces/NETReact-Server/Persistence/Persistence.csproj package Microsoft.EntityFrameworkCore.Sqlite -v 8.0.1 -s https://api.nuget.org/v3/index.json `
  - adds reference in Persistence .csproj
- to list available dotnet tools -> `dotnet tool list -g`
- for global tool installs, https://www.nuget.org/packages/dotnet-ef
  - `dotnet tool install --global dotnet-ef --version 8.0.1`
  - probably have to match runtime version of .NET, but not sure about EF core version for projects
  - you can check available dotnet-ef commands in the nuget page as well.
  - update by doing `dotnet tool update` instead of `install`
- for initial migration `dotnet ef migrations add InitialCreate -s API -p Persistence`
- `dotnet add /workspaces/NETReact-Server/API/API.csproj package Microsoft.EntityFrameworkCore.Design -v 8.0.1 -s https://api.nuget.org/v3/index.json`
  - adds reference in API .csproj
- `dotnet watch --project API`
- Had issue with ConString, use `dotnet watch --project API run --environment "Development"` instead.
- Hot reload still have some issues, Author complaisn about .NET 7, I have issues in .NET 8.
  - So add the `--no-hot-reload` flag to watch command
- updated file structure so use
  - `dotnet watch --no-hot-reload --project .NET-Server/src/API run --environment "Development"` instead

### Node

- to check version: `node --version`
- in CODESPACE, nvm seems to be installed by default. (I assume its auto-updating)
- run `nvm install --lts` to install latest lts
- run `nvm use --lts` to use latest lts
- <strike>I have saved node version used for project using `node --version > .nvmrc`</strike>
  - actually, this does-not work for some reason, just specified current version.
- you can then use it using `nvm use`
- using Vite docs to create react app
  - `npm create vite@latest`
  - and name project React-UI (will create folder)
- `npm install --prefix React-UI/`
- `npm run --prefix React-UI dev`
- all dependencies are inside `package.json` file.
  - node_modules contains them, not needed for src control.
- updated `package.json` so can just run app using
  - `npm start --prefix React-UI`

### React

- Highly recommended to go through `https://www.youtube.com/watch?v=_aCqyBPZftE&list=PL82C6-O4XrHcNJd4ejg8pX5fZaIDZmXyn&index=3`
  - don't have to do it, just skimming through, he leaves nice pointers.
- check Assets vs Public folder for serving media.
- `tsconfig.json` for TypeScript specific settings
- `vite.config.ts` for configuring vite, like serving port
- access modifiers in TypeScript gets removed when compiled to javascript as it is not supported in javascript
  - just there for developer protection.
- Most comments regarding components etc are left as comments in the `.tsx` files.
- Because strict mode is enabled, when app starts, an experiment setup is run first, then real one will start, for development.
- `npm install semantic-ui-react@3.0.0-beta.2  semantic-ui-css --prefix React-UI`
- can disable strict mode by removing the element in `main.tsx`
  - this is a caveat for useEffect afik, to test cleanup cycle.
- using the dev tools, state can be directly updated, for example, in `<App />` the request response hooks states can be updated to change the list.

### Axios

- promised based HTTP client.
- JS already has fetch and stuff, and is low level,
- Axios could be a high level wrapper for this with cool features.
- Axios uses interceptors, ig kind of like a middleware?
- `npm install axios --prefix React-UI`

### Semantic-UI

- lots of components have `as` property, which can be an intrinsic property like `<h1> <h2>` etc, but also be another component.
