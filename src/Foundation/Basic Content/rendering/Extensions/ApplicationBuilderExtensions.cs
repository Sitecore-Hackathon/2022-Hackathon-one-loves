using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;

namespace Hackathon.Foundation.BasicContent.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddFoundationBasicContent(this IApplicationBuilder app)
        {
            var options = new RewriteOptions();
            options.AddRewrite(@"^(de/|en/)(assets/lottie-animation/_start.json)", @"$2", true);
            app.UseRewriter(options);

            return app;
        }
    }
}
