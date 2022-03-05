using SolrNet.Attributes;

namespace Hackathon.Foundation.Search.Models
{
    public class JobDetailSearchModel
    {
        [SolrUniqueKey("_uniqueid")]
        public string UniqueId { get; set; }

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

        [SolrField("title_t")]
        public string Title { get; set; }

        [SolrField("locations_sm")]
        public string[] Locations { get; set; }

        [SolrField("locations_titles_sm")]
        public string[] LocationsTitles { get; set; }

        [SolrField("position_sm")]
        public string[] Position { get; set; }

        [SolrField("position_title_job_s")]
        public string PositionTitle { get; set; }
    }
}
