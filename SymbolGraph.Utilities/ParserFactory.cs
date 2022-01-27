using Microsoft.Extensions.DependencyInjection;

namespace SymbolGraph.Utilities;

public class ParserFactory
{
    private static Lazy<IServiceProvider> _ParserCache = new Lazy<IServiceProvider>(
        () =>
        {
            var serviceCollection = new ServiceCollection();
            
            var parserInterface = typeof(IParser<,>);

            var types = parserInterface.Assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.IsAssignableTo(parserInterface))
                {
                    serviceCollection.AddSingleton(parserInterface, type);
                }
            }

            return serviceCollection.BuildServiceProvider();
        });

    
    public IParser<TParse, TResult> GetParser<TParse, TResult>()
    {
        return _ParserCache
            .Value
            .GetService<IParser<TParse, TResult>>();
    }
}