using System.Collections.Generic;

namespace Hackathon.Feature.Team.Models.ViewModels
{
    public class TeamOverviewViewModel
    {
        public IEnumerable<TeamDetailViewModel> TeamDetails { get; set; }
        public IEnumerable<LocationViewModel> Locations { get; set; }
    }
}
