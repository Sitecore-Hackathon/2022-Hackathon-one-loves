using System.Text.Json.Serialization;
using Hackathon.Foundation.Send.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Foundation.Send.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFoundationSend(this IServiceCollection services)
        {
            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped<ITrackHttpService, TrackHttpService>();
            services.AddClient(Constants.ClientName);
            services.AddControllers()
                .AddJsonOptions(x => { x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
            
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SitecoreSendProxy", Version = "v1" });
            //});

            return services;
        }
    }
}
