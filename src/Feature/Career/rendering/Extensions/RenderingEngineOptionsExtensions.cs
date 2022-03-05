using Hackathon.Feature.Career.Models;
using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Hackathon.Feature.Career.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureCareer(this RenderingEngineOptions options)
        {
            options
                .AddViewComponent("JobsOverview")
                .AddModelBoundView<OpenJobs>("OpenJobs");
            return options;
        }
    }
}
