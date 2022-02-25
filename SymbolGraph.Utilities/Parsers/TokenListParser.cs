using Microsoft.CodeAnalysis;

namespace SymbolGraph.Utilities;

public class TokenListParser : IParser<SyntaxTokenList, List<DocumentToken>>
{
    private readonly IParser<SyntaxToken, DocumentToken> _tokenParser;

    public TokenListParser(IParser<SyntaxToken, DocumentToken> tokenParser)
    {
        _tokenParser = tokenParser;
    }

    public async Task<List<DocumentToken>> ParseAsync(SyntaxTokenList item)
    {
        var tokens = new List<DocumentToken>(item.Count);

        foreach (var token in item)
        {
            var documentToken = await _tokenParser.ParseAsync(token);
            
            tokens.Add(documentToken);
        }

        return tokens;
    }
}