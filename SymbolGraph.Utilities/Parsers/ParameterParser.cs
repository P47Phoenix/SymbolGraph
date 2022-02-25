using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SymbolGraph.Utilities.Parsers.Models;

namespace SymbolGraph.Utilities.Parsers;

public class ParameterParser : IParser<ParameterSyntax, DocumentParameter>
{
    private readonly IParser<TypeSyntax, DocumentTypeSyntax> _typeParser;
    private readonly IParser<SyntaxTokenList, List<DocumentToken>> _tokenListParser;

    public ParameterParser(
        IParser<TypeSyntax, DocumentTypeSyntax> typeParser,
        IParser<SyntaxTokenList, List<DocumentToken>> tokenListParser)
    {
        _typeParser = typeParser;
        _tokenListParser = tokenListParser;
    }
    public async Task<DocumentParameter> ParseAsync(ParameterSyntax item)
    {
        var p = new DocumentParameter
        {
            ParameterType = await _typeParser.ParseAsync(item.Type),
            Name = item.Span.ToString(),
            Modifiers = await _tokenListParser.ParseAsync(item.Modifiers)
        };

        return p;
    }
}