Identifiers.Extensions.Newtonsoft.Json
======================
[![Build Status](https://ci.appveyor.com/api/projects/status/github/HenkKin/Identifiers.Extensions.Newtonsoft.Json?branch=master&svg=true)](https://ci.appveyor.com/project/HenkKin/Identifiers-Extensions-Newtonsoft-Json) 
[![NuGet](https://img.shields.io/nuget/dt/Identifiers.Extensions.Newtonsoft.Json.svg)](https://www.nuget.org/packages/Identifiers.Extensions.Newtonsoft.Json) 
[![NuGet](https://img.shields.io/nuget/vpre/Identifiers.Extensions.Newtonsoft.Json.svg)](https://www.nuget.org/packages/Identifiers.Extensions.Newtonsoft.Json)
[![BCH compliance](https://bettercodehub.com/edge/badge/HenkKin/Identifiers.Extensions.Newtonsoft.Json?branch=master)](https://bettercodehub.com/)

### Summary

The Identifiers.Extensions.Newtonsoft.Json library is an extension on [Identifiers](https://github.com/HenkKin/Identifiers/).

This library is Cross-platform, supporting `netstandard2.1`.

### Installing Identifiers.Extensions.Newtonsoft.Json

You should install [Identifiers.Extensions.Newtonsoft.Json with NuGet](https://www.nuget.org/packages/Identifiers.Extensions.Newtonsoft.Json):

    Install-Package Identifiers.Extensions.Newtonsoft.Json

Or via the .NET Core command line interface:

    dotnet add package Identifiers.Extensions.Newtonsoft.Json

Either commands, from Package Manager Console or .NET Core CLI, will download and install Identifiers.Extensions.Newtonsoft.Json and all required dependencies.

### Dependencies

- [Identifiers](https://www.nuget.org/packages/Identifiers/)
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)

### Usage

If you're using Newtonsoft.Json and you want to use this Identifier type in your models, then you can use [Identifiers.Extensions.Newtonsoft.Json](https://github.com/HenkKin/Identifiers.Extensions.Newtonsoft.Json/) package which includes JsonConverters.

To use it:

```csharp
...
using Identifiers.Extensions.Newtonsoft.Json;

public class Startup
{
    ...
    
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
		var defaultJsonSerializerSettings = new JsonSerializerSettings();

		// register both JsonConverters
		defaultJsonSerializerSettings.Converters.Add(new IdentifierJsonConverter<int>());
		defaultJsonSerializerSettings.Converters.Add(new NullableIdentifierJsonConverter<int>());

		JsonConvert.DefaultSettings = () => defaultJsonSerializerSettings;
        ...
    }
    
    ...
```

### Debugging

If you want to debug the source code, thats possible. [SourceLink](https://github.com/dotnet/sourcelink) is enabled. To use it, you  have to change Visual Studio Debugging options:

Debug => Options => Debugging => General

Set the following settings:

[&nbsp;&nbsp;] Enable Just My Code

[X] Enable source server support

[X] Enable source link support


Now you can use 'step into' (F11).
