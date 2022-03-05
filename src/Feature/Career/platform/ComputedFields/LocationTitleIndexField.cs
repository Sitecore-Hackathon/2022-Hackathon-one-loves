using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Diagnostics;
using System.Linq;
using Sitecore.Globalization;

namespace Hackathon.Feature.Career.ComputedFields
{
    public class LocationTitleIndexField : IComputedIndexField
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
            Sitecore.Data.Fields.MultilistField locations = indexableItem.Item.Fields["Locations"];

            using (new LanguageSwitcher(indexableItem.Item.Language))
            {
                var titles = locations?.GetItems()?.Select(item => item["Title"]);

                return titles;
            }
        }
    }
}