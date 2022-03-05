using System;
using System.Collections.Generic;
using SolrNet.Attributes;

namespace Hackathon.Foundation.Search.Models
{
    public class BlogPostSearchModel
    {
        [SolrField("*")]
        public IDictionary<string, object> OtherFields { get; set; }

        [SolrUniqueKey("_uniqueid")]
        public string UniqueId { get; set; }

        [SolrField("_name")]
        public string Name { get; set; }

        [SolrField("_latestversion")]
        public bool LatestVersion { get; set; }

        [SolrField("_template")]
        public string Template { get; set; }

        [SolrField("_language")]
        public string Language { get; set; }

        [SolrField("_fullpath")]
        public string FullPath { get; set; }

        [SolrField("_path")]
        public string[] Path { get; set; }

        [SolrField("url_s")]
        public string Url { get; set; }



        [SolrField("pagetitle_t")]
        public string PageTitle { get; set; }

        [SolrField("teasertitle_t")]
        public string TeaserTitle { get; set; }

        [SolrField("teasertext_t")]
        public string TeaserText { get; set; }

        [SolrField("postbody_t")]
        public string PostBody { get; set; }

        [SolrField("tags_sm")]
        public string[] Tags { get; set; }

        [SolrField("tags_titles_sm")]
        public string[] TagTitles { get; set; }

        [SolrField("releasedate_tdt")]
        public DateTime ReleaseDate { get; set; }

        [SolrField("author_sm")]
        public string[] Author { get; set; }

        [SolrField("author_name_s")]
        public string AuthorName { get; set; }

        [SolrField("author_surname_s")]
        public string AuthorSurname { get; set; }

        [SolrField("timetoread_t_en")]
        public string TimeToRead { get; set; }

        [SolrField("featuredimage_url_s")]
        public string FeaturedImageUrl { get; set; }

        [SolrField("featuredimage_alttext_s")]
        public string FeaturedImageAltText { get; set; }
    }
}
