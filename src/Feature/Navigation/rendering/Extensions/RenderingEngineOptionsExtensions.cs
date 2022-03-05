using Hackathon.Feature.Navigation.Models;
using Hackathon.Feature.Navigation.Models.Tags;
using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Hackathon.Feature.Navigation.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureNavigation(this RenderingEngineOptions options)
        {
            options.AddModelBoundView<Header>("Header")
                   .AddModelBoundView<Footer>("Footer")
                   .AddModelBoundView<TagsNavigation>("TagsNavigation");
            return options;
        }
    }
}
