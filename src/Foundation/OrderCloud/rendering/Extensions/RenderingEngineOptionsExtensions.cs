using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Hackathon.Foundation.OrderCloud.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureOrderCloud(this RenderingEngineOptions options)
        {
            options
                .AddViewComponent("Product");
//                .AddModelBoundView<Techtalk>("Techtalk");
            return options;
        }
    }
}
