using System.Runtime.Serialization;
using Sitecore.LayoutService.Client.Response.Model.Properties;

namespace Hackathon.Foundation.SitecoreExtensions.Models.Properties
{
    public class ExtendedHyperLink : HyperLink
    {
        [DataMember(EmitDefaultValue = false)]
        public string Id { get; set; }
    }
}
