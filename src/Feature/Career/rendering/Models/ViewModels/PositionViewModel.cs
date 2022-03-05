using System;

namespace Hackathon.Feature.Career.Models.ViewModels
{
    public class PositionViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsClearSelection { get; set; }
    }
}
