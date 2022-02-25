using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SymbolGraph.Utilities;

namespace SymbolGraph.UtilitiesTests;

public class AssemblySetupTest
{
    private const string _solutionFilePath = "../../../../SymbolGraph.sln";

    private static Lazy<SolutionDetail> _lazy = new(() => Helper
        .ParseSolutionAsync(_solutionFilePath)
        .ConfigureAwait(false)
        .GetAwaiter()
        .GetResult());

    public static SolutionDetail ParsedSolutionDetail => _lazy.Value;
}