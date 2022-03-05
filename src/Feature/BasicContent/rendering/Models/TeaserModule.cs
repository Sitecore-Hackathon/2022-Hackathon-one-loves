using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.BasicContent.Models
{
    public class TeaserModule
    {
        public TextField Headline { get; set; }
        public RichTextField CopyText { get; set; }
        public ImageField Image { get; set; }
        public HyperLinkField Link { get; set; }
    }
}
