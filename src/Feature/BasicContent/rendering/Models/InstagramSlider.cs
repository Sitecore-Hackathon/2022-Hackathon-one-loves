using System.Collections.Generic;
using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.BasicContent.Models
{
    public class InstagramSlider
    {
        public TextField Headline { get; set; }
        public TextField CopyText { get; set; }
        public TextField AltText { get; set; }

        [SitecoreComponentField]
        public List<string> Links { get; set; }
    }
}
