namespace SymbolGraph.Utilities.Parsers.Models;

public class DocumentPropertyDeclaration
{
    public DocumentTypeSyntax PropertyType { get; set; } = new ();
    public string Name { get; set; } = String.Empty;
}