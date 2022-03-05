using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Team.Models
{
    public class TeamSection
    {
        public TextField Headline { get; set; }
        public ContentListField<TeamDetail> Team { get; set; }
        public HyperLinkField Link { get; set; }
        public CheckboxField IsRandom { get; set; }
    }
}
