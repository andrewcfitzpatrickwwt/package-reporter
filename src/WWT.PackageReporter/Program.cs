using Microsoft.Build.Construction;
using Microsoft.Build.Definition;
using Microsoft.Build.Evaluation;

namespace WWT.PackageReporter;

internal class Program
{
    static void Main(string[] args)
    {
        var path = ParseArguments(args);
        var sln = SolutionFile.Parse(path);
        var projects = sln.ProjectsByGuid.Values.Select(p => Project.FromFile(p.AbsolutePath, new ProjectOptions())).ToList();
        
        
    }
    
    private static string ParseArguments(string[] args)
    {
        if (!args.Any() || args[0] == "-h" || args[0] == "--help")
        {
            DisplayHelp();
            Environment.Exit(0);
        }

        var path = args[0];

        if (!File.Exists(path))
        {
            Console.WriteLine("The solution file does not exist.");
            Environment.Exit(1);
        }
        
        return path;
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
