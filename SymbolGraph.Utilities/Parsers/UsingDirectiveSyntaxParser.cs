using Microsoft.CodeAnalysis.CSharp.Syntax;
using SymbolGraph.Utilities.Parsers.Models;

namespace SymbolGraph.Utilities.Parsers;

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