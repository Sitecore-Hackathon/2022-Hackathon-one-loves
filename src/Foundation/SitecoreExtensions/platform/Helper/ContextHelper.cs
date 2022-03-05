using Sitecore.Data.Items;

namespace Hackathon.Foundation.SitecoreExtensions.Helper
{
    public static class ContextHelper
    {
        public static Item GetHomePageItem()
        {
            if (Sitecore.Context.Site == null || Sitecore.Context.Database == null)
                return null;

            return Sitecore.Context.Database.GetItem(Sitecore.Context.Site.ContentStartPath);
        }
    }
}