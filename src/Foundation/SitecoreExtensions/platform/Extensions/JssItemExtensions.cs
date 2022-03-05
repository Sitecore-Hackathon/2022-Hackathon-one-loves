using System.Dynamic;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace Hackathon.Foundation.SitecoreExtensions.Extensions
{
    public static class JssItemExtensions
    {
        public static object RenderSitecoreField(this Item item, string fieldName)
        {
            return RenderSitecoreField(item, fieldName, Sitecore.Context.PageMode.IsExperienceEditor);
        }
        public static object RenderSitecoreField(this Item item, ID fieldId)
        {
            return RenderSitecoreField(item, fieldId, Sitecore.Context.PageMode.IsExperienceEditor);
        }
        public static object RenderSitecoreField(this Item item, Field field)
        {
            return RenderSitecoreField(item, field, Sitecore.Context.PageMode.IsExperienceEditor);
        }

        public static object RenderSitecoreField(this Item item, string fieldName, bool isExperienceEditor)
        {
            if (item == null)
                return null;

            var field = item.Fields[fieldName];
            return item.RenderSitecoreField(field, isExperienceEditor);
        }

        public static object RenderSitecoreField(this Item item, ID fieldId, bool isExperienceEditor)
        {
            if (item == null)
                return null;

            var field = item.Fields[fieldId];
            return item.RenderSitecoreField(field, isExperienceEditor);
        }

        public static object RenderSitecoreField(this Item item, Field field, bool isExperienceEditor)
        {
            if (field == null)
                return null;

            dynamic result = new ExpandoObject();
            result.value = field.Value;
            if (isExperienceEditor)
                result.editable = FieldRenderer.Render(item, field.Name);

            return result;
        }


        public static object RenderField(string value)
        {
            dynamic result = new ExpandoObject();
            result.value = value;
            return result;
        }
    }
}