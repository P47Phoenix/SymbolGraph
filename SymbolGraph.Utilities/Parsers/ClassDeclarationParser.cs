using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SymbolGraph.Utilities;

public class ClassDeclarationParser : IParser<ClassDeclarationSyntax, DocumentClassDeclaration>
{
    public Task<DocumentClassDeclaration> ParseAsync(ClassDeclarationSyntax item)
    {
        throw new NotImplementedException();
    }
}