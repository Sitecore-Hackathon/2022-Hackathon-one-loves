using Hackathon.Foundation.Instagram.Service;
using Newtonsoft.Json.Linq;
using Sitecore.DependencyInjection;
using Sitecore.LayoutService.Configuration;
using Sitecore.Mvc.Presentation;
using System.Linq;

namespace Hackathon.Feature.BasicContent.LayoutService
{
    public class InstagramSliderContentsResolver : Sitecore.LayoutService.ItemRendering.ContentsResolvers.RenderingContentsResolver
    {
        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var item = GetContextItem(rendering, renderingConfig);

            if (item == null) return null;

            var result = ProcessItem(item, rendering, renderingConfig);

            var instagramService = ServiceLocator.ServiceProvider.GetService(typeof(IInstagramApiService)) as IInstagramApiService;

            var links = instagramService?.GetMediaList();

            var jarrayObj = new JArray();

            if (links == null || !links.Any()) return result;

            foreach (var link in links)
                jarrayObj.Add(link);

            result.Add("Links", jarrayObj);

            return result;
        }
    }
}