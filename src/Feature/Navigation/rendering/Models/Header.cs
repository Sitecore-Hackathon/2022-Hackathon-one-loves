using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Hackathon.Foundation.SitecoreExtensions.Models;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Navigation.Models
{
    public class Header: BaseViewModel
    {
        [SitecoreComponentField]
        public ContentListField<NavigationLink> HeaderLinks { get; set; }

        public ImageField DesktopLogo { get; set; }

        public ImageField MobileLogo { get; set; }

        public TextField DesktopLogoSvg { get; set; }

        public TextField MobileLogoSvg { get; set; }
    }
}
