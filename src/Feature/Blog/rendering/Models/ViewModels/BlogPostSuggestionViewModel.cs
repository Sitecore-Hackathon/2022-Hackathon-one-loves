using System.Collections.Generic;

namespace Hackathon.Feature.Blog.Models.ViewModels
{
    public class BlogPostSuggestionViewModel
    {
        public string Headline { get; set; }

        public string BlogKeywordPageUrl { get; set; }

        public IEnumerable<BlogPostViewModel> Posts { get; set; }
    }
}
