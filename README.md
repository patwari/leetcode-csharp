# C# with VSCode, xUnit, and internal debugger

## Approach 01: Command line

1. `$ dotnet new console -n Leetcode`  
   It will create a folder `Leetcode/` and keep everything in it.

1. `$ dotnet new xunit -o Leetcode.Test`  
   It will create another folder `Leetcode.Test` and keep everything in it.
   So, far these 2 projects are independent, and no connection to each other.

1. `$ dotnet add Leetcode.Test/Leetcode.Test.csproj reference Leetcode/Leetcode.csproj`  
   It will add the **Leetcode** entry into **Leetcode.Test**

1. Make your changes
1. `$ dotnet build` OR `$ dotnet test` OR `$ dotnet run`
   - Other options: `$ dotnet test --filter FullyQualifiedName~L0140` # to run tests only for a certain namespace

In this way you can control the project via terminal. However, you cannot run a debug.

## Approach 02: via VS-Code

1. install C# Dev Kit and [formulahendry.dotnet-test-explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer) extension.
1. Open vscode into new folder
1. Command Pallette > `.NET new project` > `Console App` > Folder name = `Leetcode`  
   It will create a new folder `Leetcode\`, along with other settings as well.
1. Command Pallette > `.NET new project` > `xUnity New Project` > Folder name = `Leetcode.Test`
1. By now, you should be able to test via `Test Explorer` OR `$ dotnet test`
1. `$ dotnet add Leetcode.Test/Leetcode.Test.csproj reference Leetcode/Leetcode.csproj`  
   It will add the **Leetcode** entry into **Leetcode.Test**
1. To debug

- Add breakpoints.
- use Command Pallette > `Test: Debug All test` OR `Test: Debug Tests in Current File`
  - Other options: `Test: Debug Last Run` OR `Test: Debug Failed Tests`
