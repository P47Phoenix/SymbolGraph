namespace SymbolGraph.Utilities.Parsers.Models;

public class DocumentParameter
{
    public DocumentTypeSyntax ParameterType { get; set; } = new();
    public string Name { get; set; } = String.Empty;
    public List<DocumentToken> Modifiers { get; set; } = new();
}