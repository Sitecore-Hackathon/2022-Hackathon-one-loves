using Hackathon.Foundation.BaseData.Models;
using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Service.Models
{
    public class BusinessAnimationModule
    {
        public TextField Headline { get; set; }
        public TextField CopyText { get; set; }
        public ImageField BackgroundImage { get; set; }
        public ItemLinkField<BlogKeywordSettings> BlogKeywordPage { get; set; }

        [SitecoreComponentField]
        public ContentListField<BusinessAnimationSegment> Items { get; set; }
    }
}
