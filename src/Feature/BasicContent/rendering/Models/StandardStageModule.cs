using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.BasicContent.Models
{
    public class StandardStageModule
    {
        public TextField Headline { get; set; }
        public RichTextField Description { get; set; }
        public HyperLinkField Link { get; set; }
    }
}
