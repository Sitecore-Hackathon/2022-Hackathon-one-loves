using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.BasicContent.Models
{
    public class YearSliderItem
    {
        public ImageField Image { get; set; }
        public TextField Headline { get; set; }
        public TextField CopyText { get; set; }
        public DateField Timestamp { get; set; }
    }
}
