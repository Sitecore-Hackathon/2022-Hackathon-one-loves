using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Hackathon.Feature.Team.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureTeam(this RenderingEngineOptions options)
        {
            options
                .AddViewComponent("TeamSection")
                .AddViewComponent("TeamOverview");
            return options;
        }
    }
}
