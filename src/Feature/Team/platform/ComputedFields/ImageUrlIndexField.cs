﻿using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;
using Sitecore.Diagnostics;
using Sitecore.Links.UrlBuilders;
using Sitecore.Resources.Media;
using Sitecore.Sites;

namespace Hackathon.Feature.Team.ComputedFields
{
    public class ImageUrlIndexField : IComputedIndexField
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
                ImageField img = indexableItem.Item.Fields["ProfileImage"];

                var computeFieldValue = img?.MediaItem == null ? null :
                    MediaManager.GetMediaUrl(img.MediaItem, new MediaUrlBuilderOptions()
                    {
                        AbsolutePath = false,
                        AlwaysIncludeServerUrl = true
                    });

                return computeFieldValue;
            }
        }
    }
}