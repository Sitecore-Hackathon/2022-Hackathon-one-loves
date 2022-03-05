using System;

namespace Hackathon.Project.Website.Rendering.Configuration
{
    /// <summary>
    /// Example of a custom bound configuration object. Used in the Startup class to bind configuration options
    /// and configure the Sitecore ASP.NET SDK services.
    /// </summary>
    public class SitecoreOptions
    {
        public static readonly string Key = "Sitecore";

        public Uri InstanceUri { get; set; }
        public string LayoutServicePath { get; set; } = "/sitecore/api/layout/render/jss";
        public string DefaultSiteName { get; set; }
        public string ApiKey { get; set; }
        public Uri RenderingHostUri { get; set; }
        public bool EnableExperienceEditor { get; set; }
        public string SolrUrl { get; set; }
        public string IndexName { get; set; }
        public string HomeId { get; set; }

        public Uri DictionaryServiceUri
        {
            get
            {
                if (InstanceUri == null) return null;

                var relativeUri = $"/sitecore/api/jss/dictionary/{DefaultSiteName}/[language]/?sc_apikey={{{ApiKey}}}";

                return new Uri(InstanceUri, relativeUri);
            }
        }
        public Uri LayoutServiceUri
        {
            get
            {
                if (InstanceUri == null) return null;

                return new Uri(InstanceUri, LayoutServicePath);
            }
        }
    }
}
