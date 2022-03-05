using Hackathon.Feature.Blog.Models.ViewModels;

namespace Hackathon.Feature.Blog.Models.ApiModel
{
    public class BlogPostApiItemModel : BlogPostViewModel
    {
        public new string ReleaseDate { get; set; }
        public string LearnMoreText { get; set; }
    }
}
