using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SymbolGraph.Utilities;

public class SyntaxParser : IParser<SyntaxNode, DocumentSyntax>
{
    private readonly IParser<UsingDirectiveSyntax, DocumentUsingDirectiveSyntax> _usingDirectiveSyntaxParser;
    private readonly IParser<ClassDeclarationSyntax, DocumentClassDeclaration> _classDeclarationSyntaxParser;
    private readonly IParser<InterfaceDeclarationSyntax, DocumentInterfaceDeclaration> _interfaceDeclarationSyntax;

    public SyntaxParser(
        IParser<UsingDirectiveSyntax, DocumentUsingDirectiveSyntax> usingDirectiveSyntaxParser,
        IParser<ClassDeclarationSyntax, DocumentClassDeclaration> classDeclarationSyntaxParser,
        IParser<InterfaceDeclarationSyntax, DocumentInterfaceDeclaration> interfaceDeclarationSyntax)
    {
        _usingDirectiveSyntaxParser = usingDirectiveSyntaxParser;
        _classDeclarationSyntaxParser = classDeclarationSyntaxParser;
        _interfaceDeclarationSyntax = interfaceDeclarationSyntax;
    }
    
    public async Task<DocumentSyntax> ParseAsync(SyntaxNode item)
    {

        var parsedDocumentSyntax = new DocumentSyntax();
        
        var usingDirectives = item
            .DescendantNodes()
            .OfType<UsingDirectiveSyntax>()
            .ToList();

        foreach (var usingDirectiveSyntax in usingDirectives)
        {
            var parsedUsingDirectiveSyntax = await _usingDirectiveSyntaxParser.ParseAsync(usingDirectiveSyntax);
               
            parsedDocumentSyntax.UsingDirective.Add(parsedUsingDirectiveSyntax);
        }
        
        var classDeclarations = item
            .DescendantNodes()
            .OfType<ClassDeclarationSyntax>()
            .ToList();

        foreach (var classDeclaration in classDeclarations)
        {
            var documentClassDeclaration = await _classDeclarationSyntaxParser.ParseAsync(classDeclaration);

            parsedDocumentSyntax.ClassDeclarations.Add(documentClassDeclaration);
        }
        
        
        var interfaceDeclarations = item
            .DescendantNodes()
            .OfType<InterfaceDeclarationSyntax>()
            .ToList();

        foreach (var interfaceDeclarationSyntax in interfaceDeclarations)
        {
            var documentInterfaceDeclaration = await _interfaceDeclarationSyntax.ParseAsync(interfaceDeclarationSyntax);
            
            parsedDocumentSyntax.InterfaceDeclarations.Add(documentInterfaceDeclaration);
        }

        return parsedDocumentSyntax;
    }
}