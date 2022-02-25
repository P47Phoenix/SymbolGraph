using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SymbolGraph.Utilities;

public class BlockParser : IParser<BlockSyntax, DocumentBlockSyntax>
{
    public Task<DocumentBlockSyntax> ParseAsync(BlockSyntax item)
    {
        throw new NotImplementedException();
    }
}