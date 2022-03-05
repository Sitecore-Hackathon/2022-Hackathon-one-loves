using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Diagnostics;
using Sitecore.Globalization;

namespace Hackathon.Feature.Team.ComputedFields
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
            Sitecore.Data.Fields.InternalLinkField location = indexableItem.Item.Fields["Location"];

            using (new LanguageSwitcher(indexableItem.Item.Language))
            {
                var locationTitle = location?.TargetItem?["Title"];

                return locationTitle;
            }
        }
    }
}