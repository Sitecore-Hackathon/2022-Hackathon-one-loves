using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Hackathon.Foundation.Dictionary.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFoundationDictionary(this IServiceCollection services, List<CultureInfo> supportedCultures, Uri dictionaryServiceUri)
        {
            services.AddControllers();

            // Dictionary registrations
            services.Configure<SitecoreLocalizerOptions>(options => options.Cultures = supportedCultures);
            services.AddHttpClient<ISitecoreLocalizer, SitecoreLocalizer>("sitecoreLocalizer", client =>
            {
                client.BaseAddress = dictionaryServiceUri;
            });

            services.AddTransient<ISitecoreLocalizer, SitecoreLocalizer>();
            services.AddTransient<IStringLocalizer, SitecoreLocalizer>();

            return services;
        }
    }
}
