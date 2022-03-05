using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.BasicContent.Models
{
    public class ImageWithRightText
    {
        public ImageField Image { get; set; }
        public RichTextField Text { get; set; }
    }
}
