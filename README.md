# ShogunLib.CommandLine

[![Build status](https://ci.appveyor.com/api/projects/status/ckxbe1g7a3jg6yoc?svg=true)](https://ci.appveyor.com/project/iivchenko/shogunlib-commandline) [![NuGet downloads](https://img.shields.io/nuget/vpre/ShogunLib.CommandLine.svg)](https://www.nuget.org/packages/ShogunLib.CommandLine)

Micro command line framework. Develop fast, enjoy results!

**Samples:**
  * [Fluent API](https://github.com/iivchenko/ShogunLib.CommandLine/tree/develop/Src/ShogunLib.CommandLine.OldSamples/LazyInterpreter)
  * [Using core classes](https://github.com/iivchenko/ShogunLib.CommandLine/tree/develop/Src/ShogunLib.CommandLine.OldSamples/DirectClassesUsage)
  * [Full Implementation](https://github.com/iivchenko/ShogunLib.CommandLine/tree/develop/Src/ShogunLib.CommandLine.OldSamples/OwnClassesImplementation)
  * [Exe with input params](https://github.com/iivchenko/ShogunLib.CommandLine/tree/develop/Src/ShogunLib.CommandLine.OldSamples/ExeAsCommand)  

![Sample Image](Docs/SampleImage.png)

```csharp
const string HelloCommand = "Hello";           
const string ExitCommand = "Exit";

const string NumberParameter = "-number:";

var builder = InterpreterBuilderFactory.Create();

// Setup builder
builder
	.SetHelp("Help",
			 (sender, args) =>
				 {
					 if (args.Commands.Count == 1)
					 {
						 var command = args.Commands.First();

						 Console.WriteLine("{0}\t\t\t-{1}", command.Name, command.Description);

						 foreach (var parameter in command.Parameters)
						 {
							 Console.WriteLine("{0}\t\t\t-{1}", parameter.Name, parameter.Description);
						 }
					 }
					 else
					 {
						 foreach (var command in args.Commands)
						 {
							 Console.WriteLine("{0}\t\t\t-{1}", command.Name, command.Description);
						 }
					 }
				 });

// Add Commands
builder
	.Add(HelloCommand)               
	.Add(ExitCommand);

// Setup commands
builder[HelloCommand]
	.SetDescription("Writes 'hello' to the console specified number of times")
	.SetAction(arguments =>
				   {
					   var times = arguments[NumberParameter].Any()
									   ? int.Parse(arguments[NumberParameter].First(),
												   CultureInfo.InvariantCulture)
									   : 0;

					   for (var i = 0; i < times; i++)
					   {
						   Console.WriteLine("Hello");
					   }
				   });

builder[ExitCommand]
	.SetDescription("Terminate app")
	.SetAction(arguments =>
				   {
					   isContinue = false;
					   Console.WriteLine("Press any key to exit...");
				   });

// Add parameters
builder[HelloCommand].Add(NumberParameter);

// Setup parameters
builder[HelloCommand][NumberParameter]
	.SetDescription("Number of times")
	.AddValidator(new OptionalParameterValidator())
	.AddValidator(new IntTypeValidator());

// Building interpreter
return builder.Create();
```

## Releases ##
[![Release v0.1](https://img.shields.io/badge/v%200.1-Download-brightgreen.svg)](https://github.com/iivchenko/ShogunLib.CommandLine/releases/download/v0.1/ShogunLib.CommandLine.zip) [![Release Notes v0.1](https://img.shields.io/badge/Release%20notes-Navigate-brightgreen.svg)](https://github.com/iivchenko/ShogunLib.CommandLine/releases/tag/v0.1)

## License ##

ShogunLib.CommandLine is open source software, licensed under the terms of MIT license. 
See [LICENSE](LICENSE) for details.