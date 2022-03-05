using Hackathon.Foundation.BaseData.Models;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Team.Models
{
    public class TeamDetail : _BasePage
    {
        public TextField Name { get; set; }
        public TextField Surname { get; set; }
        public HyperLinkField Email { get; set; }
        public ImageField ProfileImage { get; set; }
        public ImageField CoverImage { get; set; }
        public RichTextField Bio { get; set; }
        public HyperLinkField Website { get; set; }
        public ItemLinkField<Location> Location { get; set; }
        public ItemLinkField<Position> Position { get; set; }
        public HyperLinkField Facebook { get; set; }
        public HyperLinkField Twitter { get; set; }
    }
}
