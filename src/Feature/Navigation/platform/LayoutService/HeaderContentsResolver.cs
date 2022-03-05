using System.Linq;
using Sitecore.LayoutService.Configuration;
using Sitecore.Mvc.Presentation;

namespace Hackathon.Feature.Navigation.LayoutService
{
    public class HeaderContentsResolver : Sitecore.LayoutService.ItemRendering.ContentsResolvers.RenderingContentsResolver
    {
        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var datasource = GetContextItem(rendering, renderingConfig);
            if (datasource == null)
                return null;

            var headerLinks = datasource.Children.FirstOrDefault(x => x.TemplateID == Templates.MainNavigation.Id)
                ?.Children.Where(x => x.TemplateID == Templates.NavigationLink.Id).ToList();

            var result = ProcessItem(datasource, rendering, renderingConfig);

            if (headerLinks != null && headerLinks.Any())
                result.Add("HeaderLinks", ProcessItems(headerLinks, rendering, renderingConfig));

            return result;
        }
    }
}