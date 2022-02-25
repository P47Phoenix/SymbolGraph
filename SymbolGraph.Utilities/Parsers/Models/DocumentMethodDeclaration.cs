namespace SymbolGraph.Utilities;

public class DocumentMethodDeclaration
{
    public string Name { get; set; } = String.Empty;
    public DocumentTypeSyntax ReturnType { get; set; } = new ();
    public List<DocumentParameter> Parameters { get; set; } = new();
    public DocumentBlockSyntax Body { get; set; } = new ();
}