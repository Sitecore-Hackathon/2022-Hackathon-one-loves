using Sitecore.AspNet.RenderingEngine.Binding.Attributes;

namespace Hackathon.Foundation.SitecoreExtensions.Models
{
    public class BaseViewModel
    {
        [SitecoreContextProperty]
        public bool IsEditing { get; set; }
    }
}
