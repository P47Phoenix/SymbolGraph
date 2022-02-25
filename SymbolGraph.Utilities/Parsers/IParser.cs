namespace SymbolGraph.Utilities.Parsers;

public interface IParser<TParse, TResult>
{
    Task<TResult> ParseAsync(TParse item);
}