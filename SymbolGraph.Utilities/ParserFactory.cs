using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace SymbolGraph.Utilities;

public class ParserFactory
{
    private static Lazy<IServiceProvider> _ParserCache = new (
        () =>
        {
            var serviceCollection = new ServiceCollection();

            var parserInterface = typeof(IParser<,>);

            var types = parserInterface.Assembly.GetTypes();

            foreach (var type in types)
            {
                var parserInterfaceInstance = type.GetInterface(parserInterface.Name);
                if (parserInterfaceInstance != null)
                {
                    Log.Debug("Adding type of {type}", type.FullName);
                    serviceCollection.AddSingleton(parserInterfaceInstance, type);
                }
                else
                {
                    Log.Debug("Skipping type of {type}", type.FullName);
                }
            }

            try
            {
                return serviceCollection.BuildServiceProvider();
            }
            catch (ArgumentException argumentException)
            {
                Log.Error(argumentException, "Unable to BuildServiceProvider");
                throw;
            }
        });
    

    
    public IParser<TParse, TResult> GetParser<TParse, TResult>()
    {
        return _ParserCache
            .Value
            .GetService<IParser<TParse, TResult>>();
    }
}