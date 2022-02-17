using Microsoft.CodeAnalysis.Diagnostics;

namespace SymbolGraph.Utilities;

public class AnalyzerReferenceParser : IParser<AnalyzerReference, AnalyzerReferenceDetail>
{
    public Task<AnalyzerReferenceDetail> ParseAsync(AnalyzerReference item)
    {
        var reference = new AnalyzerReferenceDetail
        {
            Display = item.Display,
            FullPath = item.FullPath ?? string.Empty,
        };

        return Task.FromResult(reference);
    }
}