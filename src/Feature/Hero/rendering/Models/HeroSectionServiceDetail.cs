using Hackathon.Foundation.BaseData.Models;
using Hackathon.Foundation.BaseData.Models.Tags;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Hero.Models
{
    public class HeroSectionServiceDetail
    {
        public TextField Headline { get; set; }

        public RichTextField Description { get; set; }

        public ContentListField<Tag> Tags { get; set; }

        public ImageField Image { get; set; }

        public ItemLinkField<BlogKeywordSettings> BlogKeywordPage { get; set; }
    }
}
