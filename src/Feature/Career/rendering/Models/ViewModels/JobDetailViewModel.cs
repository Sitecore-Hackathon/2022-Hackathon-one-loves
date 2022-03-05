using System.Collections.Generic;

namespace Hackathon.Feature.Career.Models.ViewModels
{
    public class JobDetailViewModel
    {
        public string Title { get; set; }
        public IEnumerable<string> Locations { get; set; }
        public string Position { get; set; }
        public string Url { get; set; }
    }
}
