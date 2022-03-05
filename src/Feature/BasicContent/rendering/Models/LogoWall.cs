using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.BasicContent.Models
{
    public class LogoWall
    {
        public TextField Headline { get; set; }
        public TextField CopyText { get; set; }

        [SitecoreComponentField]
        public ContentListField<Logo> Logos { get; set; }

        public HyperLinkField Link { get; set; }

        public NumberField ItemsCount { get; set; }

        [SitecoreComponentField]
        public string CssClass { get; set; }
    }
}
