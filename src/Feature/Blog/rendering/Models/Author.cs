using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Blog.Models
{
    public class Author
    {
        [SitecoreComponentField]
        public TextField Name { get; set; }

        [SitecoreComponentField]
        public TextField Surname { get; set; }

        [SitecoreComponentField]
        public ImageField ProfileImage { get; set; }
    }
}
