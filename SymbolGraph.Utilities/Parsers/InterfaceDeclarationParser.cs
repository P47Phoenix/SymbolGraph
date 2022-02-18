using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SymbolGraph.Utilities;

public class InterfaceDeclarationParser : IParser<InterfaceDeclarationSyntax, DocumentInterfaceDeclaration>
{
    public Task<DocumentInterfaceDeclaration> ParseAsync(InterfaceDeclarationSyntax item)
    {
        throw new NotImplementedException();
    }
}