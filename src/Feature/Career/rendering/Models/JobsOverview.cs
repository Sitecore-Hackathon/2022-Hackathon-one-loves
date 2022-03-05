using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Career.Models
{
    public class JobsOverview
    {
        public NumberField NumberOfMembers { get; set; }
        public ContentListField<Location> Locations { get; set; }
        public ContentListField<Position> Positions { get; set; }
    }
}
