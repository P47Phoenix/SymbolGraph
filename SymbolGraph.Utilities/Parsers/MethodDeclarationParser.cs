using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SymbolGraph.Utilities;

public class MethodDeclarationParser : IParser<MethodDeclarationSyntax, DocumentMethodDeclaration>
{
    private readonly IParser<TypeSyntax, DocumentTypeSyntax> _predefinedTypeSyntaxParser;
    private readonly IParser<ParameterListSyntax, List<DocumentParameter>> _predefinedParameterListParser;
    private readonly IParser<BlockSyntax, DocumentBlockSyntax> _predefinedBlockParser;

    public MethodDeclarationParser(
        IParser<TypeSyntax, DocumentTypeSyntax> predefinedTypeSyntaxParser,
        IParser<ParameterListSyntax, List<DocumentParameter>> predefinedParameterListParser,
        IParser<BlockSyntax, DocumentBlockSyntax> predefinedBlockParser
    )
    {
        _predefinedTypeSyntaxParser = predefinedTypeSyntaxParser;
        _predefinedParameterListParser = predefinedParameterListParser;
        _predefinedBlockParser = predefinedBlockParser;
    }
    
    public async Task<DocumentMethodDeclaration> ParseAsync(MethodDeclarationSyntax item)
    {
        var documentMethodDeclaration = new DocumentMethodDeclaration
        {
            Name = item.Identifier.Text,
            ReturnType = await _predefinedTypeSyntaxParser.ParseAsync(item.ReturnType),
            Parameters = await _predefinedParameterListParser.ParseAsync(item.ParameterList),
            Body = await _predefinedBlockParser.ParseAsync(item.Body)
        };

        return documentMethodDeclaration;
    }
}