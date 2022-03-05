using System.Collections.Generic;
using SolrNet.Attributes;

namespace Hackathon.Foundation.Search.Models
{
    public class SearchModel
    {
        [SolrUniqueKey("_uniqueid")]
        public string UniqueId { get; set; }

        [SolrField("_template")]
        public string Template { get; set; }

        [SolrField("_language")]
        public string Language { get; set; }

        [SolrField("*")]
        public IDictionary<string, object> Fields { get; set; }
    }
}
