using Hackathon.Feature.Service.Models;
using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Hackathon.Feature.Service.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureService(this RenderingEngineOptions options)
        {
            options
                .AddModelBoundView<BusinessAnimationModule>("BusinessAnimationModule")
                .AddModelBoundView<ServicesModule>("ServicesModule");
            return options;
        }
    }
}
