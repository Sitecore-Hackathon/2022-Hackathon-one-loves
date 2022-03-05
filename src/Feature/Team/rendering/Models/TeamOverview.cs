using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Team.Models
{
    public class TeamOverview
    {
        public NumberField NumberOfMembers { get; set; }
        public ContentListField<Location> Locations { get; set; }
    }
}
