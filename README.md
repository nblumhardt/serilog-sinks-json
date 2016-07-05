# Serilog.Sinks.Json [![Build status](https://ci.appveyor.com/api/projects/status/22173h76wlpvmqvk/branch/master?svg=true)](https://ci.appveyor.com/project/NicholasBlumhardt/serilog-sinks-json/branch/master)

### Notice

**This package is being made obsolete.** The 2.1+ versions of the File, Rolling File and Console sinks now all have configuration overloads that accept an `ITextFormatter`.

For example, for _Serilog.Sinks.File_ version 2.1.0 and above, the following configuration is equivalent to `JsonFile` from this package:

```csharp
Log.Logger = new LoggerConfiguration()
    .WriteTo.File(new JsonFormatter(), "./my-app-log.json")
    .CreateLogger();
```

The XML `<appSettings>` support in _Serilog.Settings.AppSettings_ 2.0 and above will accept a formatter type name:

```xml
<appSettings>
  <add key="serilog:write-to:File.path" value="./my-app-log.json" />
  <add key="serilog:write-to:File.formatter"
       value="Serilog.Formatting.Json.JsonFormatter, Serilog" />
```

Because of the better long-term prospects of the built-in support, this package is no longer recommended for use and is not being maintained.

## Usage

Outputs Serilog events in a lossless JSON format. This is useful for local logging when files may later be analyzed mechanically,
or when running on a platform that collects stdout as a log stream (i.e. Docker).

```json
{"Timestamp":"2016-05-03T10:43:07.6408174+10:00","Level":"Information",
 "MessageTemplate":"Hello, world from {Username}!","Properties":{"Username":"nblumhardt"}}
```

Serilog has sinks that write text to log files or the console. These can accept a standard Serilog `JsonFormatter` in 
place of the default text formatter, but doing this is not easily discoverable, nor compatible with the current
`<appSettings>` and `config.json` configuration readers.

This package adds extension methods to `LoggerConfiguration` for directly creating JSON variants of the standard
console, file and rolling file sinks.

### Installing

All three wrappers are in the _Serilog.Sinks.Json_ package.

```powershell
Install-Package Serilog.Sinks.Json -Pre -DependencyVersion Highest
```

**Note:** on the regular CLR platforms (.NET 4.5.1 etc.) the package targets Serilog 1.5. On .NET Core, Serilog 2.0.0-beta
is targeted. Installation may sometimes require manually adding a reference to _System.Runtime.dll_ and _System.IO.dll_ from
the _Profile259_ reference assemblies before installing the
package, and manually removing the references afterwards. Hopefully the tooling around this will be tidied up soon.

### Console

In code:

```csharp
Log.Logger = new LoggerConfiguration()
    .WriteTo.JsonConsole()
    .CreateLogger();
```

In XML:

```xml
<configuration>
	<appSettings>
		<add key="serilog:using:Json" value="Serilog.Sinks.Json" />
		<add key="serilog:write-to:JsonConsole" />
	</appSettings>
</configuration>
```

See also: [Serilog.Sinks.Console](https://github.com/serilog/serilog-sinks-console).

### File

The file format produced is a newline-separated JSON stream, hence the `.jsnl` extension
used in the examples.

In code:

```csharp
Log.Logger = new LoggerConfiguration()
    .WriteTo.JsonFile(@"C:\Logs\myapp.jsnl")
	.CreateLogger();
```

In XML:

```xml
<configuration>
	<appSettings>
		<add key="serilog:using:Json" value="Serilog.Sinks.Json" />
		<add key="serilog:write-to:JsonFile.path" value="C:\Logs\myapp.jsnl" />
	</appSettings>
</configuration>
```

See also: [Serilog.Sinks.File](https://github.com/serilog/serilog-sinks-file).

### Rolling File

The file format produced is a newline-separated JSON stream, hence the `.jsnl` extension
used in the examples.

```csharp
Log.Logger = new LoggerConfiguration()
    .WriteTo.JsonRollingFile(@"C:\Logs\myapp-{Date}.jsnl")
	.CreateLogger();
```

In XML:

```xml
<configuration>
	<appSettings>
		<add key="serilog:using:Json" value="Serilog.Sinks.Json" />
		<add key="serilog:write-to:JsonRollingFile.pathFormat" value="C:\Logs\myapp-{Date}.jsnl" />
	</appSettings>
</configuration>
```

See also: [Serilog.Sinks.RollingFile](https://github.com/serilog/serilog-sinks-rollingfile).
