using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SymbolGraph.Utilities;

public class UsingDirectiveSyntaxParser : IParser<UsingDirectiveSyntax,DocumentUsingDirectiveSyntax>
{
    public Task<DocumentUsingDirectiveSyntax> ParseAsync(UsingDirectiveSyntax item)
    {
        var documentUsingDirectiveSyntax = new DocumentUsingDirectiveSyntax()
        {
            Namespace = item.Name.ToFullString()
        };

        return Task.FromResult(documentUsingDirectiveSyntax);
    }
}