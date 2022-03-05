using Sitecore;
using Sitecore.Data;
using Sitecore.LayoutService.Configuration;
using Sitecore.Mvc.Presentation;

namespace Hackathon.Feature.BasicContent.LayoutService
{
    public class DatasourceOrContextItemContentsResolver : Sitecore.LayoutService.ItemRendering.ContentsResolvers.RenderingContentsResolver
    {
        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var item = GetContextItem(rendering, renderingConfig) ?? Context.Item;

            var result = ProcessItem(item, rendering, renderingConfig);

            return result;
        }
    }
}