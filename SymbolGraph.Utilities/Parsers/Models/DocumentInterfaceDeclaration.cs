namespace SymbolGraph.Utilities.Parsers.Models;

public class DocumentInterfaceDeclaration
{
    public List<DocumentPropertyDeclaration> Properties { get; set; } = new();

    public List<DocumentMethodDeclaration> Methods { get; set; } = new();
}