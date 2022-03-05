using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Foundation.BaseData.Models.Tags
{
    public class Tag
    {
        [SitecoreComponentField]
        public TextField Title { get; set; }

        [SitecoreComponentField]
        public TextField Description { get; set; }
    }
}
