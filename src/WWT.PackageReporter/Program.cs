using Microsoft.Build.Construction;

namespace WWT.PackageReporter;

internal class Program
{
    static void Main(string[] args)
    {
        var path = ParseArguments(args);
        
        var sln = SolutionFile.Parse("");
    }
    
    private static string ParseArguments(string[] args)
    {
        if (!args.Any() || args[0] == "-h" || args[0] == "--help")
        {
            DisplayHelp();
            Environment.Exit(0);
        }

        return args[0];
    }

    private static void DisplayHelp()
    {
        Console.WriteLine("Usage: dotnet run -- <solution path>");
        Console.WriteLine("");
        Console.WriteLine("Parse a solution's nuget package references and report on the versions.");
        Console.WriteLine("");
        Console.WriteLine("Options:");
        Console.WriteLine("   -h, --help - Show help for this program");
    }
}
