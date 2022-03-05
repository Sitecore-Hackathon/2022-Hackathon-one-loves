using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.BasicContent.Models
{
    public class YearSlider
    {
        [SitecoreComponentField]
        public ContentListField<YearSliderItem> YearSlides { get; set; }
    }
}
