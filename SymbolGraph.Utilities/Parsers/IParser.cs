namespace SymbolGraph.Utilities;

public interface IParser<TParse, TResult>
{
    Task<TResult> ParseAsync(TParse item);
}