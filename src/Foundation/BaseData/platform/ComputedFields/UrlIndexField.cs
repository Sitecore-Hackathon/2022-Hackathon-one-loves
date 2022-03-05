using Microsoft.Extensions.DependencyInjection;
using Sitecore.Abstractions;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.DependencyInjection;
using Sitecore.Diagnostics;
using Sitecore.Links;
using Sitecore.Sites;

namespace Hackathon.Foundation.BaseData.ComputedFields
{
    public class UrlIndexField : IComputedIndexField
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

            using (new SiteContextSwitcher(SiteContext.GetSite("Global")))
            {
                var service = ServiceLocator.ServiceProvider.GetService<BaseLinkManager>();

                var urlBuilderOptions = LinkManager.GetDefaultUrlBuilderOptions();
                urlBuilderOptions.ShortenUrls = new bool?(true);
                urlBuilderOptions.AlwaysIncludeServerUrl = new bool?(false);

                var url = service.GetItemUrl(indexableItem.Item, urlBuilderOptions);

                return url;
            }
        }
    }
}