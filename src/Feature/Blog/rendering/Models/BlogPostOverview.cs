using Sitecore.AspNet.RenderingEngine.Binding;
using Sitecore.LayoutService.Client.Response.Model.Fields;
using System.Collections.Generic;
using Hackathon.Foundation.BaseData.Models;
using Hackathon.Foundation.BaseData.Models.Tags;

namespace Hackathon.Feature.Blog.Models
{
    public class BlogPostOverview
    {
        public TextField Headline { get; set; }

        public NumberField NumberOfTags { get; set; }

        public NumberField NumberOfPosts { get; set; }

        public ItemLinkField<Tag> SelectedTag { get; set; }

        public ItemLinkField<BlogKeywordSettings> BlogKeywordPage { get; set; }

        [SitecoreComponentProperty(Name = "Parameters")]
        public Dictionary<string, string> Parameters { get; set; }
    }
}
