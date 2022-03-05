using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;

namespace Hackathon.Feature.Blog.ComputedFields
{
    public class SortOrderIndexField : IComputedIndexField
    {
        public string FieldName { get; set; }

        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            var item = (Item)(indexable as SitecoreIndexableItem);
            if (item == null)
                return null;

            if (string.IsNullOrEmpty(item[Sitecore.FieldIDs.Sortorder]))
            {
                return 0;
            }

            return int.TryParse(item[Sitecore.FieldIDs.Sortorder], out var sortOrder)
                ? sortOrder
                : 0;
        }
    }
}