using Hackathon.Foundation.BaseData.Models;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Career.Models
{
    public class JobDetail : _BasePage
    {
        public TextField Title { get; set; }
        public ContentListField<Location> Locations { get; set; }
        public ItemLinkField<Position> Position { get; set; }
    }
}
