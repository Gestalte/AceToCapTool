# Warning

<span style="color:red">
Casual Arma Players no longer use the optional files from the Ace addons folder and instead use the optional files added as seperate mods to the workshop. This code is merely kept around on the off chance that we decide to return to the dark days of having to copy these files by ourselves instead of just using a preset file.</span>

# AceToCapTool
Copies or deletes ACE optional files, used by the [Casual Arma Players](https://units.arma3.com/unit/cap) unit, to or from ACE addons folder. This is the procedure described in step 2 of this document: https://steamcommunity.com/sharedfiles/filedetails/?id=937923182

To compile the source code into a single .exe file run this command from CMD inside the working directory: ```dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true``` You can then find the generated .exe file in the ```...AceToCapTool\bin\Release\netcoreapp3.1\win-x64\publish``` folder. This requires you to have the [.Net Core SDK](https://dotnet.microsoft.com/download) installed

the .exe file should be placed in your !Workshop\\@ace folder. You can create a shortcut from the .exe or run it directly.
