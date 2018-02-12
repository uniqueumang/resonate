using Microsoft.Extensions.DependencyInjection;
using Resonate.BusinessService.Interface;
using Resonate.MockBusinessService;

namespace Resonate.DI
{
    public static class DependencyInjectionSetup
    {
        public static void Setup(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDataService, MockDataService>();
        }
    }
}