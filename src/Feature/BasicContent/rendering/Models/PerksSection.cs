using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.BasicContent.Models
{
    public class PerksSection
    {
        public TextField Headline { get; set; }

        [SitecoreComponentField]
        public ContentListField<Perk> Perks { get; set; }
    }
}
