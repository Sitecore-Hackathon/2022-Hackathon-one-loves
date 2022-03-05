using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Service.Models
{
    public class ServicesModule
    {
        public TextField Headline { get; set; }

        [SitecoreComponentField]
        public ContentListField<ServicesModuleItem> Items { get; set; }
    }
}
