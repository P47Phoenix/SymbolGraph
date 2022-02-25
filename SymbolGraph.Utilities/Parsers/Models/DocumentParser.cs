using Microsoft.CodeAnalysis;

namespace SymbolGraph.Utilities.Parsers.Models;

public class DocumentParser : IParser<Document, DocumentDetail>
{
    private readonly IParser<SyntaxNode, DocumentSyntax> _documentSyntaxParser;

    public DocumentParser(IParser<SyntaxNode, DocumentSyntax> documentSyntaxParser)
    {
        _documentSyntaxParser = documentSyntaxParser;
    }
    public async Task<DocumentDetail> ParseAsync(Document item)
    {
        var parsedDocumentDetail = new DocumentDetail
        {
            SourceCodeKind = item.SourceCodeKind,
            Name = item.Name,
            FilePath = item.FilePath ?? String.Empty,
            SupportsSemanticModel = item.SupportsSemanticModel,
            SupportsSyntaxTree = item.SupportsSyntaxTree,
            Folders = item.Folders,
            DocumentId = item.Id.Id
        };

        var syntaxRoot = await item.GetSyntaxRootAsync();

        if (syntaxRoot != null)
        {
            var parsedSyntax = await _documentSyntaxParser.ParseAsync(syntaxRoot);

            parsedDocumentDetail.Syntax = parsedSyntax;
            
        }

        return parsedDocumentDetail;
    }
}