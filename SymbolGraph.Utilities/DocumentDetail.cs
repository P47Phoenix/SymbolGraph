using Microsoft.CodeAnalysis;
using SymbolGraph.Utilities.Parsers.Models;

namespace SymbolGraph.Utilities;

public class DocumentDetail
{
    public string Name { get; set; } = string.Empty;
    public string FilePath { get; set; }
    public SourceCodeKind SourceCodeKind { get; set; }
    public bool SupportsSemanticModel { get; set; }
    public bool SupportsSyntaxTree { get; set; }
    public IReadOnlyList<string> Folders { get; set; } = new List<string>();
    public Guid DocumentId { get; set; } = Guid.Empty;
    public DocumentSyntax Syntax { get; set; }
}