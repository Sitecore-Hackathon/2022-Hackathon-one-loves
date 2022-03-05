using Hackathon.Feature.BasicContent.Models;
using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Hackathon.Feature.BasicContent.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureBasicContent(this RenderingEngineOptions options)
        {
            options
                .AddPartialView("Accordion")
                .AddPartialView("PromoContainer")
                .AddModelBoundView<PromoCard>("PromoCard")
                .AddModelBoundView<SectionHeader>("SectionHeader")
                .AddModelBoundView<HeroBanner>("HeroBanner")
                .AddModelBoundView<AccordionItem>("AccordionItem")
                .AddModelBoundView<ImageBlock>("ImageBlock")
                .AddModelBoundView<CubeModule>("CubeModule")
                .AddModelBoundView<FullWidthMediaSlider>("FullWidthMediaSlider")
                .AddModelBoundView<MediaSliderItem>("MediaSliderItem")
                .AddModelBoundView<NarrowMediaSlider>("NarrowMediaSlider")
                .AddModelBoundView<FAQ>("FAQ")
                .AddModelBoundView<LogoWall>("LogoWall")
                .AddModelBoundView<ErrorDetails>("ErrorDetails")
                .AddModelBoundView<ImageWithLeftText>("ImageWithLeftText")
                .AddModelBoundView<InstagramSlider>("InstagramSlider")
                .AddModelBoundView<YearSlider>("YearSlider")
                .AddModelBoundView<YearSliderItem>("YearSliderItem")
                .AddModelBoundView<ImageWithRightText>("ImageWithRightText")
                .AddModelBoundView<PerksSection>("PerksSection")
                .AddModelBoundView<StandardStageModule>("StandardStageModule")
                .AddModelBoundView<GeneralTextModule>("GeneralTextModule")
                .AddModelBoundView<StandardTextModule>("StandardTextModule")
                .AddModelBoundView<TextSource>("TextSource")
                .AddModelBoundView<TeaserModule>("TeaserModule")
                .AddModelBoundView<BackButton>("BackButton")
                .AddModelBoundView<Heading>("Heading");
            return options;
        }
    }
}
