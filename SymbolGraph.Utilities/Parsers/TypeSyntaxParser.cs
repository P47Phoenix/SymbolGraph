using Microsoft.CodeAnalysis.CSharp.Syntax;
using SymbolGraph.Utilities.Parsers.Models;

namespace SymbolGraph.Utilities.Parsers;

public class TypeSyntaxParser : IParser<TypeSyntax, DocumentTypeSyntax>
{
    public Task<DocumentTypeSyntax> ParseAsync(TypeSyntax item)
    {
        var d = new DocumentTypeSyntax
        {
            Name = item.Span.ToString()
        };

        return Task.FromResult(d);
    }
}