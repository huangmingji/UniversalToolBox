# UniversalToolBoxDesktop  
一个基于 MAUI 的万能工具箱  
https://learn.microsoft.com/zh-cn/dotnet/maui/mac-catalyst/cli?view=net-maui-8.0

dotnet build -t:Run -f net8.0-maccatalyst  

创建 .app  
https://learn.microsoft.com/zh-cn/dotnet/maui/mac-catalyst/deployment/publish-unsigned  
dotnet publish UniversalToolBox.csproj -f net8.0-maccatalyst -c Release -p:CreatePackage=false --self-contained true -p:PublishSingleFile=true --runtime osx-arm64

创建.pkg  
https://learn.microsoft.com/zh-cn/dotnet/maui/mac-catalyst/deployment/publish-macos  
dotnet publish UniversalToolBox.csproj -f net8.0-maccatalyst -c Release -p:CreatePackage=true --self-contained false -r osx-arm64

创建.dmg  
https://learn.microsoft.com/zh-cn/dotnet/maui/mac-catalyst/deployment/publish-macos  
dotnet publish -f net8.0-maccatalyst -c Release -p:CreatePackage=true --self-contained false -r osx-arm64

创建 .exe  
https://learn.microsoft.com/zh-cn/dotnet/maui/windows/deployment/publish-cli  