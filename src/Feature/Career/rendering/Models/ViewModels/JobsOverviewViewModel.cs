using System.Collections.Generic;

namespace Hackathon.Feature.Career.Models.ViewModels
{
    public class JobsOverviewViewModel
    {
        public IEnumerable<JobDetailViewModel> JobDetails { get; set; }
        public IEnumerable<LocationViewModel> Locations { get; set; }
        public IEnumerable<PositionViewModel> Positions { get; set; }
    }
}
