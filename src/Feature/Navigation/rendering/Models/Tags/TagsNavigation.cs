using Hackathon.Foundation.BaseData.Models;
using Hackathon.Foundation.BaseData.Models.Tags;
using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Navigation.Models.Tags
{
    public class TagsNavigation
    {
        [SitecoreComponentField]
        public ContentListField<Tag> Tags { get; set; }

        public ItemLinkField<BlogKeywordSettings> BlogKeywordPage { get; set; }
    }
}
