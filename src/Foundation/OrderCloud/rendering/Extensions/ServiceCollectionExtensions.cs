using System.Text.Json.Serialization;
using Hackathon.Foundation.OrderCloud.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Foundation.OrderCloud.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFoundationOrderCloud(this IServiceCollection services)
        {
            services.AddScoped<IOrderCloudService, OrderCloudService>();
            services.AddControllers()
                .AddJsonOptions(x => { x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
          
            return services;
        }
    }
}
