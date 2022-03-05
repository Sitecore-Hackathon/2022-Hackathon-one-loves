using Hackathon.Feature.Blog.Models;
using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Hackathon.Feature.Blog.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureBlog(this RenderingEngineOptions options)
        {
            options
                .AddModelBoundView<BlogPost>("BlogPost")
                .AddViewComponent("BlogPostSuggestion")
                .AddViewComponent("BlogPostOverview")
                .AddViewComponent("BlogKeyword")
                .AddModelBoundView<FeaturedBlogs>("FeaturedBlogs")
                .AddModelBoundView<BlogPostOverview>("BlogPostOverview")
                .AddModelBoundView<Techtalk>("Techtalk");
            return options;
        }
    }
}
