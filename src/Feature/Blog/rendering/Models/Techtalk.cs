using Hackathon.Foundation.BaseData.Models;
using Hackathon.Foundation.BaseData.Models.Tags;
using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Blog.Models
{
    public class Techtalk
    {
        public TextField Headline { get; set; }

        [SitecoreComponentField]
        public ContentListField<BlogPost> BlogPosts { get; set; }

        public HyperLinkField RedirectLink { get; set; }

        public ItemLinkField<BlogKeywordSettings> BlogKeywordPage { get; set; }

        public ItemLinkField<Tag> Tag { get; set; }
    }
}
