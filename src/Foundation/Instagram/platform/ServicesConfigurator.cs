using Hackathon.Foundation.Instagram.Service;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Hackathon.Foundation.Instagram
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddTransient<IInstagramApiService, InstagramApiService>();
        }
    }
}