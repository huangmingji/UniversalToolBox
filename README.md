# UniversalToolBoxDesktop  
一个基于 MAUI 的万能工具箱  
https://learn.microsoft.com/zh-cn/dotnet/maui/mac-catalyst/cli?view=net-maui-8.0

dotnet build -t:Run -f net8.0-maccatalyst  

创建 .app  
https://learn.microsoft.com/zh-cn/dotnet/maui/mac-catalyst/deployment/publish-unsigned  
dotnet publish -f net8.0-maccatalyst -c Release -p:CreatePackage=false

创建.pkg  
https://learn.microsoft.com/zh-cn/dotnet/maui/mac-catalyst/deployment/publish-macos  
dotnet publish -f net8.0-maccatalyst -c Release -p:CreatePackage=true

创建 .exe  
https://learn.microsoft.com/zh-cn/dotnet/maui/windows/deployment/publish-cli
dotnet publish -f net7.0-windows10.0.19041.0 -c Release -p:RuntimeIdentifierOverride=win10-x64