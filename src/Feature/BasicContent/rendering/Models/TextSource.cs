using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.BasicContent.Models
{
    public class TextSource
    {
        public RichTextField Text { get; set; }

        [SitecoreComponentField]
        public string CssClass { get; set; }
    }
}
