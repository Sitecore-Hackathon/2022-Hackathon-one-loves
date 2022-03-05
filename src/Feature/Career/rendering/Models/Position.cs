using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Career.Models
{
    public class Position
    {
        public TextField Title { get; set; }

        public CheckboxField ClearSelection { get; set; }
    }
}
