using Hackathon.Foundation.SitecoreExtensions.Models.Properties;
using Sitecore.LayoutService.Client.Response.Model;

namespace Hackathon.Foundation.SitecoreExtensions.Models.Fields
{
    public class ExtendedHyperLinkField : WrappedEditableField<ExtendedHyperLink>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.LayoutService.Client.Response.Model.Fields.HyperLinkField" /> class.
        /// </summary>
        public ExtendedHyperLinkField()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.LayoutService.Client.Response.Model.Fields.HyperLinkField" /> class.
        /// </summary>
        /// <param name="value">The initial value.</param>
        public ExtendedHyperLinkField(ExtendedHyperLink value) => this.Value = value;
    }
}
