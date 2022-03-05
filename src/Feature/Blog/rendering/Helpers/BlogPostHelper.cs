using System;
using System.Collections.Generic;
using System.Linq;
using Hackathon.Feature.Blog.Models;
using Hackathon.Feature.Blog.Models.ApiModel;
using Hackathon.Feature.Blog.Models.ViewModels;
using Hackathon.Foundation.Search.Models;
using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace Hackathon.Feature.Blog.Helpers
{
    public class BlogPostHelper
    {
        public static IEnumerable<BlogPostViewModel> Map(IEnumerable<BlogPostSearchModel> data)
        {
            return data.Select(Map);
        }

        public static BlogPostViewModel Map(BlogPostSearchModel data)
        {
            return new BlogPostViewModel()
            {
                Title = data.PageTitle,
                TeaserTitle = data.TeaserTitle,
                TeaserText = data.TeaserText,
                PostBody = data.PostBody,
                Tags = data.TagTitles,
                ReleaseDate = data.ReleaseDate != DateTime.MinValue ? (DateTime?)data.ReleaseDate : null,
                AuthorName = data.AuthorName,
                AuthorSurname = data.AuthorSurname,
                TimeToRead = data.TimeToRead,
                Url = data.Url,
                FeaturedImageUrl = data.FeaturedImageUrl,
                FeaturedImageAltText = data.FeaturedImageAltText
            };
        }

        public static BlogPostApiItemModel Map(BlogPostViewModel data)
        {
            return new BlogPostApiItemModel()
            {
                Title = data.Title,
                TeaserTitle = data.TeaserTitle,
                TeaserText = data.TeaserText,
                PostBody = data.PostBody,
                Tags = data.Tags,
                ReleaseDate = data.ReleaseDate?.ToString("d MMMM yyyy HH:mm:ss"),
                AuthorName = data.AuthorName,
                AuthorSurname = data.AuthorSurname,
                TimeToRead = data.TimeToRead,
                Url = data.Url,
                FeaturedImageUrl = data.FeaturedImageUrl,
                FeaturedImageAltText = data.FeaturedImageAltText
            };
        }

        public static IEnumerable<BlogPostViewModel> Map(IEnumerable<ItemLinkField<BlogPost>> data)
        {
            return data.Select(Map);
        }

        public static BlogPostViewModel Map(ItemLinkField<BlogPost> data)
        {
            return new BlogPostViewModel()
            {
                Title = data.Fields?.PageTitle?.Value,
                TeaserTitle = data.Fields?.TeaserTitle?.Value,
                TeaserText = data.Fields?.TeaserText?.Value,
                PostBody = data.Fields?.PostBody?.Value,
                Tags = data.Fields?.Tags?.Select(tag => tag.Target?.Title?.Value).ToArray(),
                ReleaseDate = data.Fields?.ReleaseDate?.Value != DateTime.MinValue ? data.Fields?.ReleaseDate?.Value : null,
                AuthorName = data.Fields?.Author?.Target?.Name?.Value,
                AuthorSurname = data.Fields?.Author?.Target?.Surname?.Value,
                TimeToRead = data.Fields?.TimeToRead?.Value,
                Url = data.Url,
                FeaturedImageUrl = data.Fields?.FeaturedImage?.Value?.Src,
                FeaturedImageAltText = data.Fields?.FeaturedImage?.Value?.Alt
            };
        }
    }
}
