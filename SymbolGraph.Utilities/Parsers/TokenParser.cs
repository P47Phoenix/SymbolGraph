using Microsoft.CodeAnalysis;

namespace SymbolGraph.Utilities;

public class TokenParser : IParser<SyntaxToken, DocumentToken>
{
    public Task<DocumentToken> ParseAsync(SyntaxToken item)
    {
        var token = new DocumentToken
        {
            Name = item.Text
        };
        
        return Task.FromResult(token);
    }
}