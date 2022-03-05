using Hackathon.Foundation.SitecoreExtensions.Models.Fields;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Navigation.Models
{
    public class NavigationLink
    {
        public TextField Title { get; set; }
        public ExtendedHyperLinkField Link { get; set; }
    }
}
