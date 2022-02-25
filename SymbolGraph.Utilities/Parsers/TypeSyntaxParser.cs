using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SymbolGraph.Utilities;

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