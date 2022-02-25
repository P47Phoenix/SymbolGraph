using Microsoft.CodeAnalysis;
using SymbolGraph.Utilities.Parsers.Models;

namespace SymbolGraph.Utilities.Parsers;

public class MetadataReferenceParser : IParser<MetadataReference, MetadataReferenceDetail>
{
    public Task<MetadataReferenceDetail> ParseAsync(MetadataReference item)
    {
        var metadataReferenceDetail = new MetadataReferenceDetail
        {
            Display = item.Display,
            Aliases = item.Properties.Aliases,
            Kind = item.Properties.Kind
        };
        
        return Task.FromResult(metadataReferenceDetail);
    }
}