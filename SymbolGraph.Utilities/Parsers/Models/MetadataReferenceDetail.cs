using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace SymbolGraph.Utilities.Parsers.Models;

public class MetadataReferenceDetail
{
    public string? Display { get; set; }
    public ImmutableArray<string> Aliases { get; set; }
    public MetadataImageKind Kind { get; set; }
}