using Hackathon.Feature.Hero.Models;
using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Hackathon.Feature.Hero.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureHero(this RenderingEngineOptions options)
        {
            options
                .AddModelBoundView<HeroImage>("HeroImage")
                .AddModelBoundView<HeroSectionMedia>("HeroSectionMedia")
                .AddModelBoundView<HeroSectionText>("HeroSectionText")
                .AddModelBoundView<HeroSectionTeamDetail>("HeroSectionTeamDetail")
                .AddModelBoundView<HeroSectionServiceDetail>("HeroSectionServiceDetail")
                .AddModelBoundView<HeroSectionVideo>("HeroSectionVideo")
                .AddModelBoundView<EmbeddedVideo>("EmbeddedVideo")
                .AddModelBoundView<VimeoVideo>("VimeoVideo")
                .AddModelBoundView<YouTubeVideo>("YouTubeVideo");
            return options;
        }
    }
}
