namespace SymbolGraph.Utilities.Parsers.Models;

/// <summary>
/// 
/// </summary>
public class DocumentSyntax
{
    /// <summary>
    /// 
    /// </summary>
    public List<DocumentUsingDirectiveSyntax> UsingDirective { get; set; } = new();

    /// <summary>
    /// 
    /// </summary>
    public List<DocumentClassDeclaration> ClassDeclarations { get; set; } = new();
    
    /// <summary>
    /// 
    /// </summary>
    public List<DocumentInterfaceDeclaration> InterfaceDeclarations { get; set; } = new();
}