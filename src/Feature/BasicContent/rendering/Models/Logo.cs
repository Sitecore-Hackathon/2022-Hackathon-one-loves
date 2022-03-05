using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.BasicContent.Models
{
    public class Logo
    {
        public ImageField Image { get; set; }
        public TextField Title { get; set; }
        public HyperLinkField Url { get; set; }
    }
}