using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SymbolGraph.Utilities;

public class ClassDeclarationParser : IParser<ClassDeclarationSyntax, DocumentClassDeclaration>
{
    private readonly IParser<PropertyDeclarationSyntax, DocumentPropertyDeclaration> _propertyDeclarationParser;
    private readonly IParser<MethodDeclarationSyntax, DocumentMethodDeclaration> _methodDeclarationParser;

    public ClassDeclarationParser(
        IParser<PropertyDeclarationSyntax, DocumentPropertyDeclaration> propertyDeclarationParser,
        IParser<MethodDeclarationSyntax, DocumentMethodDeclaration> methodDeclarationParser)
    {
        _propertyDeclarationParser = propertyDeclarationParser;
        _methodDeclarationParser = methodDeclarationParser;
    }
    
    public async Task<DocumentClassDeclaration> ParseAsync(ClassDeclarationSyntax item)
    {
        var documentClassDeclaration = new DocumentClassDeclaration();
        
        var propertyDeclarationSyntaxNodes = item
            .ChildTokens()
            .OfType<PropertyDeclarationSyntax>()
            .ToList();
     
        foreach (var propertyDeclarationSyntaxNode in propertyDeclarationSyntaxNodes)
        {
            var propertyDeclaration = await _propertyDeclarationParser.ParseAsync(propertyDeclarationSyntaxNode);
            
            documentClassDeclaration.Properties.Add(propertyDeclaration);
        }
        
        
        var methodDeclarationSyntaxNodes = item
            .ChildTokens()
            .OfType<MethodDeclarationSyntax>()
            .ToList();

        foreach (var methodDeclarationSyntaxNode in methodDeclarationSyntaxNodes)
        {
            var documentMethodDeclaration = await _methodDeclarationParser.ParseAsync(methodDeclarationSyntaxNode);
            
            documentClassDeclaration.Methods.Add(documentMethodDeclaration);
        }
        
        return documentClassDeclaration;
    }
}