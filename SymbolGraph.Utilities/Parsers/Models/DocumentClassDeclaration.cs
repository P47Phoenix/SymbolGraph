namespace SymbolGraph.Utilities.Parsers.Models;

public class DocumentClassDeclaration
{
    public List<DocumentPropertyDeclaration> Properties { get; set; } = new();

    public List<DocumentMethodDeclaration> Methods { get; set; } = new();
}