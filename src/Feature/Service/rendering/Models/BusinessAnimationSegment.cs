using Hackathon.Foundation.BaseData.Models.Tags;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Service.Models
{
    public class BusinessAnimationSegment
    {
        public TextField Title { get; set; }
        public TextField CopyText { get; set; }
        public ContentListField<Tag> Tags { get; set; }
        public TextField SectionName { get; set; }
        public ImageField Image { get; set; }
        public HyperLinkField Link { get; set; }
    }
}
