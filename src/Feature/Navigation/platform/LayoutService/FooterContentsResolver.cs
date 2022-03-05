using System.Linq;
using Sitecore.LayoutService.Configuration;
using Sitecore.Mvc.Presentation;

namespace Hackathon.Feature.Navigation.LayoutService
{
    public class FooterContentsResolver : Sitecore.LayoutService.ItemRendering.ContentsResolvers.RenderingContentsResolver
    {
        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var item = GetContextItem(rendering, renderingConfig);
            if (item == null)
                return null;

            var footerLinks = item.Children.FirstOrDefault(x => x.TemplateID == Templates.FooterLinkFolder.Id)
                ?.Children.Where(x => x.TemplateID == Templates.NavigationLink.Id).ToList();
            var socialMedias = item.Children.FirstOrDefault(x => x.TemplateID == Templates.SocialMediaFolder.Id)
                ?.Children.Where(x => x.TemplateID == Templates.SocialMediaItem.Id).ToList();


            var result = ProcessItem(item, rendering, renderingConfig);
            if(footerLinks != null && footerLinks.Any())
                result.Add("FooterLinks", ProcessItems(footerLinks, rendering, renderingConfig));

            if (socialMedias != null && socialMedias.Any())
                result.Add("SocialMedias", ProcessItems(socialMedias, rendering, renderingConfig));

            return result;
        }
    }
}