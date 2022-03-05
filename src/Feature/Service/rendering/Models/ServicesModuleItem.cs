using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Service.Models
{
    public class ServicesModuleItem
    {
        public TextField Title { get; set; }
        public TextField CopyText { get; set; }
        public HyperLinkField Link { get; set; }
    }
}
