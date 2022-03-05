using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.BasicContent.Models
{
    public class CubeModule
    {
        [SitecoreComponentField]
        public ContentListField<CubeModuleItem> Items { get; set; }
    }
}
