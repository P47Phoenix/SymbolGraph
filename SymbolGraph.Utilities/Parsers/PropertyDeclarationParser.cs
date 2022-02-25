using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SymbolGraph.Utilities;

public class PropertyDeclarationParser : IParser<PropertyDeclarationSyntax, DocumentPropertyDeclaration>
{
    private readonly IParser<TypeSyntax, DocumentTypeSyntax> _predefinedTypeSyntaxParser;

    public PropertyDeclarationParser(
        IParser<TypeSyntax, DocumentTypeSyntax> predefinedTypeSyntaxParser
    )
    {
        _predefinedTypeSyntaxParser = predefinedTypeSyntaxParser;
    }
    public async Task<DocumentPropertyDeclaration> ParseAsync(PropertyDeclarationSyntax item)
    {
        var documentPropertyDeclaration = new DocumentPropertyDeclaration
        {
            PropertyType = await _predefinedTypeSyntaxParser.ParseAsync(item.Type),
            Name = item.Identifier.Text,
        };

        return documentPropertyDeclaration;
    }
}