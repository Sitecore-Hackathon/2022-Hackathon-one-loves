using Hackathon.Foundation.BaseData.Models;
using Hackathon.Foundation.BaseData.Models.Tags;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Blog.Models
{
    public class BlogPost : _BasePage
    {
        public TextField TeaserTitle { get; set; }

        public TextField TeaserText { get; set; }

        public RichTextField PostBody { get; set; }

        public ContentListField<Tag> Tags { get; set; }

        public DateField ReleaseDate { get; set; }

        public ItemLinkField<Author> Author { get; set; }

        public TextField TimeToRead { get; set; }

        public ImageField FeaturedImage { get; set; }
    }
}
