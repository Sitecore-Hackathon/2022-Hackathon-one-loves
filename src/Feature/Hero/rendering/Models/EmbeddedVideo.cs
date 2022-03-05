using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Hero.Models
{
    public class EmbeddedVideo
    {
        public TextField Poster { get; set; }
        public TextField Source { get; set; }
        public ItemLinkField<VideoType> Type { get; set; }
    }
}
