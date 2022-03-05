using Hackathon.Feature.Career.Models;
using Hackathon.Feature.Career.Models.ViewModels;
using Hackathon.Foundation.Search.Models;
using Sitecore.LayoutService.Client.Response.Model.Fields;
using System.Collections.Generic;
using System.Linq;
using Hackathon.Feature.Career.Models.ApiModel;

namespace Hackathon.Feature.Career.Helpers
{
    public class JobDetailHelper
    {
        public static IEnumerable<JobDetailViewModel> Map(IEnumerable<JobDetailSearchModel> data)
        {
            return data.Select(Map);
        }

        public static JobDetailViewModel Map(JobDetailSearchModel data)
        {
            return new JobDetailViewModel()
            {
                Title = data.Title,
                Locations = data.LocationsTitles,
                Position = data.PositionTitle,
                Url = data.Url
            };
        }

        public static JobDetailApiModel Map(JobDetailViewModel data)
        {
            return new JobDetailApiModel()
            {
                Title = data.Title,
                Locations = data.Locations,
                Position = data.Position,
                Url = data.Url
            };
        }

        public static IEnumerable<JobDetailViewModel> Map(IEnumerable<ItemLinkField<JobDetail>> data)
        {
            return data.Select(Map);
        }

        public static JobDetailViewModel Map(ItemLinkField<JobDetail> data)
        {
            return new JobDetailViewModel()
            {
                Title = data.Fields?.Title?.Value,
                Locations = data.Fields?.Locations?.Select(l => l.Fields?.Title?.Value),
                Position = data.Fields?.Position?.Fields?.Title?.Value,
                Url = data.Url
            };
        }
    }
}
