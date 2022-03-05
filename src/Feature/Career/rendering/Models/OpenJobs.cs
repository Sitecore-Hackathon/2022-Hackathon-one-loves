using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Career.Models
{
    public class OpenJobs
    {
        public TextField Headline { get; set; }
        public ContentListField<JobDetail> JobDetails { get; set; }
        public HyperLinkField Link { get; set; }
    }
}
