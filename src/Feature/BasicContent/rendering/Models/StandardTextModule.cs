using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.BasicContent.Models
{
    public class StandardTextModule
    {
        public TextField Title { get; set; }
        public TextField Headline { get; set; }
        public RichTextField Text { get; set; }
        public HyperLinkField Link { get; set; }
    }
}
