using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Diagnostics;
using Sitecore.Globalization;

namespace Hackathon.Feature.Career.ComputedFields
{
    public class PositionTitleIndexField : IComputedIndexField
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
            Sitecore.Data.Fields.InternalLinkField position = indexableItem.Item.Fields["Position"];

            using (new LanguageSwitcher(indexableItem.Item.Language))
            {
                var title = position?.TargetItem?["Title"];

                return title;
            }
        }
    }
}