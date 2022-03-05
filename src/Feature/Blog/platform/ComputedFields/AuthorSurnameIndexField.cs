using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Diagnostics;
using Sitecore.Globalization;

namespace Hackathon.Feature.Blog.ComputedFields
{
    public class AuthorSurnameIndexField : IComputedIndexField
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
            Sitecore.Data.Fields.InternalLinkField author = indexableItem.Item.Fields["Author"];

            using (new LanguageSwitcher(indexableItem.Item.Language))
            {
                var name = author?.TargetItem?["Surname"];

                return name;
            }
        }
    }
}