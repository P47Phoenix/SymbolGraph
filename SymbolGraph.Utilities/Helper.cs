using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace SymbolGraph.Utilities;

public static class Helper
{
    private static readonly ParserFactory _parserFactory = new ParserFactory();
    public static async Task<SolutionDetail> ParseSolutionAsync(string filepath)
    {
        var workspace = MSBuildWorkspace.Create();
        var solution = await workspace.OpenSolutionAsync(filepath);
        var solutionParser = _parserFactory.GetParser<Solution, SolutionDetail>();
        return await solutionParser.ParseAsync(solution);
    }
}