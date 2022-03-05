using Hackathon.Foundation.BaseData.Models;
using Hackathon.Foundation.BaseData.Models.Tags;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Blog.Models
{
    public class BlogPostSuggestion
    {
        public TextField Headline { get; set; }

        public ContentListField<Tag> Tags { get; set; }

        public ItemLinkField<Author> Author { get; set; }

        public ContentListField<BlogPost> Posts { get; set; }

        public ItemLinkField<BlogKeywordSettings> BlogKeywordPage { get; set; }
    }
}
