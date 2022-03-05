using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.BasicContent.Models
{
    public class FAQ
    {
        public TextField Headline { get; set; }
        [SitecoreComponentField]
        public ContentListField<FAQItem> Items { get; set; }
    }
}
