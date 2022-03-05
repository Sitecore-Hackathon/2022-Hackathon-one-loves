using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Hero.Models
{
    public class HeroSectionTeamDetail
    {
        public TextField Name { get; set; }

        public TextField Surname { get; set; }

        public ImageField ProfileImage { get; set; }

        public ItemLinkField<Location> Location { get; set; }

        public ItemLinkField<Position> Position { get; set; }
    }
}
