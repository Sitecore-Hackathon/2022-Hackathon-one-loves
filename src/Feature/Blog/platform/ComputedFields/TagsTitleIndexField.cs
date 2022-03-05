using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using System.Linq;

namespace Hackathon.Feature.Blog.ComputedFields
{
    public class TagsTitleIndexField : IComputedIndexField
    {
        public string FieldName { get; set; }
        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Assert.ArgumentNotNull(indexable, "indexable");

            if (!(indexable is SitecoreIndexableItem indexableItem))
            {
                Log.Warn($"{this} : unsupported IIndexable type : {indexable.GetType()}", this);
                return null;
            }
            Sitecore.Data.Fields.MultilistField tags = indexableItem.Item.Fields["Tags"];

            using (new LanguageSwitcher(indexableItem.Item.Language))
            {
                var titles = tags?.GetItems()?.Select(item => item["Title"].ToLowerInvariant());

                return titles;
            }
        }
    }
}