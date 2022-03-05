using System;

namespace Hackathon.Feature.Blog.Models.ViewModels
{
    public class BlogPostViewModel
    {
        public string Title { get; set; }

        public string TeaserTitle { get; set; }

        public string TeaserText { get; set; }

        public string PostBody { get; set; }

        public string[] Tags { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string AuthorName { get; set; }

        public string AuthorSurname { get; set; }

        public string TimeToRead { get; set; }

        public string Url { get; set; }

        public string FeaturedImageUrl { get; set; }

        public string FeaturedImageAltText { get; set; }
    }
}
