using Microsoft.CodeAnalysis.CSharp.Syntax;
using SymbolGraph.Utilities.Parsers.Models;

namespace SymbolGraph.Utilities.Parsers;

public class InterfaceDeclarationParser : IParser<InterfaceDeclarationSyntax, DocumentInterfaceDeclaration>
{
    private readonly IParser<PropertyDeclarationSyntax, DocumentPropertyDeclaration> _propertyDeclarationParser;
    private readonly IParser<MethodDeclarationSyntax, DocumentMethodDeclaration> _methodDeclarationParser;

    public InterfaceDeclarationParser(
        IParser<PropertyDeclarationSyntax, DocumentPropertyDeclaration> propertyDeclarationParser,
        IParser<MethodDeclarationSyntax, DocumentMethodDeclaration> methodDeclarationParser)
    {
        _propertyDeclarationParser = propertyDeclarationParser;
        _methodDeclarationParser = methodDeclarationParser;
    }
    
    public async Task<DocumentInterfaceDeclaration> ParseAsync(InterfaceDeclarationSyntax item)
    {
        var interfaceDeclaration = new DocumentInterfaceDeclaration();
        
        var propertyDeclarationSyntaxNodes = item
            .ChildTokens()
            .OfType<PropertyDeclarationSyntax>()
            .ToList();

        foreach (var propertyDeclarationSyntaxNode in propertyDeclarationSyntaxNodes)
        {
            var propertyDeclaration = await _propertyDeclarationParser.ParseAsync(propertyDeclarationSyntaxNode);
            
            interfaceDeclaration.Properties.Add(propertyDeclaration);
        }
        
        
        var methodDeclarationSyntaxNodes = item
            .ChildTokens()
            .OfType<MethodDeclarationSyntax>()
            .ToList();

        foreach (var methodDeclarationSyntaxNode in methodDeclarationSyntaxNodes)
        {
            var documentMethodDeclaration = await _methodDeclarationParser.ParseAsync(methodDeclarationSyntaxNode);
            
            interfaceDeclaration.Methods.Add(documentMethodDeclaration);
        }

        return interfaceDeclaration;
    }
}