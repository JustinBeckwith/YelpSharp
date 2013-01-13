%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe YelpSharp.sln /t:Clean,Rebuild /p:Configuration=Release /fileLogger

if not exist Download\Net4 mkdir Download\Net4\
if not exist Download\package\lib\net4 mkdir Download\package\lib\net4\
copy YelpSharp\bin\Release\YelpSharp.dll Download\
copy YelpSharp\bin\Release\YelpSharp.xml Download\
copy YelpSharp\bin\Release\YelpSharp.dll Download\Net4\
copy YelpSharp\bin\Release\YelpSharp.xml Download\Net4\
copy YelpSharp\bin\Release\YelpSharp.dll Download\Package\lib\net4\

if not exist Download\WindowsPhone8 mkdir Download\WindowsPhone8\
if not exist Download\package\lib\windowsphone8 mkdir Download\package\lib\windowsphone8\
copy YelpSharp.WindowsPhone\bin\Release\YelpSharp.WindowsPhone.dll Download\WindowsPhone8\
copy YelpSharp.WindowsPhone\bin\Release\YelpSharp.WindowsPhone.xml Download\WindowsPhone8\
copy YelpSharp.WindowsPhone\bin\Release\YelpSharp.WindowsPhone.dll Download\Package\lib\windowsphone8\

.nuget\nuget.exe update -self
.nuget\nuget.exe pack YelpSharp.nuspec -BasePath Download\Package -Output Download