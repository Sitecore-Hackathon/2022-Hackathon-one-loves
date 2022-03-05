using Hackathon.Foundation.SitecoreExtensions.Models;
using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Navigation.Models
{
    public class Footer : BaseViewModel
    {
        public RichTextField EmailText { get; set; }
        public HyperLinkField Email { get; set; }
        public RichTextField SocialLinksText { get; set; }
        public TextField Copyright { get; set; }

        [SitecoreComponentField]
        public ContentListField<NavigationLink> FooterLinks { get; set; }

        [SitecoreComponentField]
        public ContentListField<SocialMediaItem> SocialMedias { get; set; }
    }
}
