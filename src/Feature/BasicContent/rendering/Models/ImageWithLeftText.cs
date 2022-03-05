using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.BasicContent.Models
{
    public class ImageWithLeftText
    {
        public RichTextField Text { get; set; }
        public ImageField Image { get; set; }
    }
}
