# AceToCapTool
Copies or deletes ACE optional files to or from ACE addons folder. This is the procedure described in: https://steamcommunity.com/sharedfiles/filedetails/?id=937923182

To compile the source code into a single .exe file run this command from CMD inside the working directory: ```dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true``` This requires you to have the [.Net Core SDK](https://dotnet.microsoft.com/download)  installed

the .exe file should be placed in your !Workshop\@ace folder. You can create a shortcut from the .exe or use it directly.
