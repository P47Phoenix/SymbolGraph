namespace SymbolGraph.Utilities;

public class DocumentInterfaceDeclaration
{
    public List<DocumentPropertyDeclaration> Properties { get; set; } = new();

    public List<DocumentMethodDeclaration> Methods { get; set; } = new();
}