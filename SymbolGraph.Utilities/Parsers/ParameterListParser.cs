using Microsoft.CodeAnalysis.CSharp.Syntax;
using SymbolGraph.Utilities.Parsers.Models;

namespace SymbolGraph.Utilities.Parsers;

public class ParameterListParser : IParser<ParameterListSyntax, List<DocumentParameter>>
{
    private readonly IParser<ParameterSyntax,DocumentParameter> _parameterParser;

    public ParameterListParser(IParser<ParameterSyntax, DocumentParameter> parameterParser)
    {
        _parameterParser = parameterParser;
    }
    
    public async Task<List<DocumentParameter>> ParseAsync(ParameterListSyntax item)
    {
        List<DocumentParameter> list = new List<DocumentParameter>(item.Parameters.Count);

        foreach (var parameterSyntax in item.Parameters)
        {
            var p = await _parameterParser.ParseAsync(parameterSyntax);
            list.Add(p);
        }

        return list;
    }
}