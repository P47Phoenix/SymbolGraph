using Microsoft.CodeAnalysis.CSharp.Syntax;
using SymbolGraph.Utilities.Parsers.Models;

namespace SymbolGraph.Utilities.Parsers;

public class BlockParser : IParser<BlockSyntax, DocumentBlockSyntax>
{
    public Task<DocumentBlockSyntax> ParseAsync(BlockSyntax item)
    {
        throw new NotImplementedException();
    }
}