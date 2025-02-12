# C# with VSCode, xUnit, and internal debugger

This document contains list of steps to setup dotnet with vscode. Primarily this is for my own use, and may not contain the best of approaches!! 

## Setup Approach 01: Command line

1. `$ dotnet new console -n Leetcode`  
   It will create a folder `Leetcode/` and keep everything in it.

1. `$ dotnet new xunit -o Leetcode.Test`  
   It will create another folder `Leetcode.Test` and keep everything in it.
   So, far these 2 projects are independent, and no connection to each other.

1. `$ dotnet add Leetcode.Test/Leetcode.Test.csproj reference Leetcode/Leetcode.csproj`  
   _format = [destination, source]_  
   It will add a ProjectReference of the **Leetcode.csproj** into **Leetcode.Test.csproj**

1. `$ dotnet sln add Leetcode/Leetcode.csproj`
1. `$ dotnet sln add Leetcode.Test/Leetcode.Test.csproj`  
   It will register both projects as part of the main Solution.
1. **DONE**

## Setup Approach 02: Command Line: Tests in Same folder as Code

dotnet recommended approach is to keep Code and Tests in separate folders. However, if you want to keep both in same project (as I have), you can use

**Option 1 (official): **

1. `$ dotnet new console -n Leetcode`
1. `$ cd Leetcode\`
1. `$ dotnet add package xunit`
1. `$ dotnet add package xunit.runner.visualstudio`
1. **DONE**

**Option 2 (Better) **
Create 2 separate projects - both console and test. And then move the Test project inside the main.

1. `$ dotnet new console -n Leetcode`
1. `$ dotnet new xunit -o Leetcode.Test`
1. Copy uncommon entries from `Leetcode.Test.csproj` file into `Leetcode.csproj`. This is better as it adds some additional packages as well.
1. Move your own cs files from `Leetcode.Test\` to `Leetcode\`, so that you do not lose your files.
1. I like to use a `Usings.cs` containing global usings. Move that as per your choice.
1. Delete the `Leetcode.Test\` project folder.
1. `$ dotnet sln add Leetcode/Leetcode.csproj`
1. **DONE**

## Setup Approach 03: via VS-Code

1. install C# Dev Kit and [formulahendry.dotnet-test-explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer) extension.
1. This will automatically install a latest version of dotnet. If not -> manually download LTS from https://dotnet.microsoft.com/en-us/download and install it.
1. Open vscode into new folder.
1. Command Pallette > `.NET new project` > `Console App` > Folder name = `Leetcode`  
   It will create a new folder `Leetcode\`, along with other settings as well.
1. Command Pallette > `.NET new project` > `xUnity New Project` > Folder name = `Leetcode.Test`
1. `$ dotnet add Leetcode.Test/Leetcode.Test.csproj reference Leetcode/Leetcode.csproj`
   It will add a ProjectReference of the **Leetcode.csproj** into **Leetcode.Test.csproj**
1. **DONE**

## How to use: Command line

- After set-up You can run/build/test your projects.
- Make your changes

1. `$ dotnet build` OR `$ dotnet test` OR `$ dotnet run`
   - Other options: `$ dotnet test --filter FullyQualifiedName~L0140` # to run tests only for a certain namespace

NOTE: However, you cannot run a debug via command line.

## How to use: via VS-Code

- After set-up You can run/build/test your projects.
- Make your changes

1. Use Menu > View > Testing. This `Test Explorer` window will contains all tests found in all projects. Now you may run any test.

1. To debug

- Add breakpoints.
- use Command Pallette > `Test: Debug All test` OR `Test: Debug Tests in Current File`
  - Other options: `Test: Debug Last Run` OR `Test: Debug Failed Tests`

## Additional Notes:
- For some reason, the dotnet installed via homebrew didn't work for me.
   - `brew install dotnet` would install dotnet, and even run the tests. But wasn't able to debug.
   - `brew install --cask dotnet-sdk` also didn't

## To Upgrade dotnet version
1. Download from https://dotnet.microsoft.com/en-us/download. And install.
1. Following commands are useful to check
   - `which dotnet`
   - `dotnet --list-sdks`
   - `dotnet --version`
1. You can upgrade your project by
   1. Using Dotnet upgrade-assistant
      - `dotnet tool install -g upgrade-assistant`
      - `upgrade-assistant upgrade .` in project directory.
   1. Manually (preferred)
      - Open project in vscode.
      - Open all `*.csproj` files and replace TargetFramework to `net9.0` or whatever version you've updated to. Note, that it needs only 2 digits.
      - `dotnet restore`
      - `dotnet build`