using System.Collections.Generic;

namespace Hackathon.Feature.Team.Models.ViewModels
{
    public class TeamSectionViewModel
    {
        public string Headline { get; set; }
        public IEnumerable<TeamDetailViewModel> Team { get; set; }
        public string LinkUrl { get; set; }
        public string LinkText { get; set; }
    }
}
