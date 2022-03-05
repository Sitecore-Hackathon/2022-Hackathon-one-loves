using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;

namespace Hackathon.Feature.Blog.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddFeatureBlog(this IApplicationBuilder app)
        {
            var options = new RewriteOptions();
            options.AddRewrite(@"(\S*)/(\S*)/topics/(.*)", @"$1/$2?tag=$3", true);
            app.UseRewriter(options);

            return app;
        }
    }
}
