using SolrNet.Attributes;

namespace Hackathon.Foundation.Search.Models
{
    public class TeamDetailSearchModel
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

        [SolrField("name_t_en")]
        public string Name { get; set; }

        [SolrField("surname_t_en")]
        public string Surname { get; set; }

        [SolrField("location_sm")]
        public string[] Location { get; set; }

        [SolrField("location_title_s")]
        public string LocationTitle { get; set; }

        [SolrField("position_sm")]
        public string[] Position { get; set; }

        [SolrField("position_title_team_s")]
        public string PositionTitle { get; set; }

        [SolrField("profileimage_url_s")]
        public string ProfileImageUrl { get; set; }

        [SolrField("profileimage_t")]
        public string ProfileImageAltText { get; set; }
    }
}
