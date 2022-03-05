using Hackathon.Foundation.BaseData.Models;
using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Blog.Models
{
    public class FeaturedBlogs
    {
        [SitecoreComponentField]
        public ItemLinkField<BlogPost> HighlightedBlogPost { get; set; }

        [SitecoreComponentField]
        public ContentListField<BlogPost> FeaturedBlogPosts { get; set; }

        public ItemLinkField<BlogKeywordSettings> BlogKeywordPage { get; set; }
    }
}
