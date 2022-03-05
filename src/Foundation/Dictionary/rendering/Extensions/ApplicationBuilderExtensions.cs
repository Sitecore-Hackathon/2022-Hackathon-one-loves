using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;

namespace Hackathon.Foundation.Dictionary.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IEndpointRouteBuilder AddFoundationDictionary(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                "localization",
                "api/localization/reload",
                new { controller = "Localization", action = "Reload" }
            );
            return endpoints;
        }

        public static IApplicationBuilder AddFoundationDictionary(this IApplicationBuilder app)
        {
            var options = new RewriteOptions();
            options.AddRewrite(@"^(de$|de/)(.*)", @"de-DE/$2", true);
            app.UseRewriter(options);

            return app;
        }
    }
}
