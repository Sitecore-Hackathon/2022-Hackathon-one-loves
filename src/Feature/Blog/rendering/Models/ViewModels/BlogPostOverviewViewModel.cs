using System.Collections.Generic;

namespace Hackathon.Feature.Blog.Models.ViewModels
{
    public class BlogPostOverviewViewModel
    {
        public string Headline { get; set; }

        public int NumberOfTags { get; set; }

        public string BlogKeywordPageUrl { get; set; }

        public IEnumerable<BlogPostViewModel> Posts { get; set; }

        public string SelectedTag { get; set; }

        public bool ShowLoadMore { get; set; }

        public bool ShowGoToAll { get; set; }
    }
}
