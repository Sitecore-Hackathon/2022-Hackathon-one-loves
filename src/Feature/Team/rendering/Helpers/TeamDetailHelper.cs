using Hackathon.Feature.Team.Models;
using Hackathon.Feature.Team.Models.ViewModels;
using Hackathon.Foundation.Search.Models;
using Sitecore.LayoutService.Client.Response.Model.Fields;
using System.Collections.Generic;
using System.Linq;
using Hackathon.Feature.Team.Models.ApiModel;

namespace Hackathon.Feature.Team.Helpers
{
    public class TeamDetailHelper
    {
        public static IEnumerable<TeamDetailViewModel> Map(IEnumerable<TeamDetailSearchModel> data)
        {
            return data.Select(Map);
        }

        public static TeamDetailViewModel Map(TeamDetailSearchModel data)
        {
            return new TeamDetailViewModel()
            {
                Name = data.Name,
                Surname = data.Surname,
                Location = data.LocationTitle,
                Position = data.PositionTitle,
                ProfileImageUrl = data.ProfileImageUrl,
                ProfileImageAltText = data.ProfileImageAltText,
                Url = data.Url
            };
        }

        public static TeamDetailApiModel Map(TeamDetailViewModel data)
        {
            return new TeamDetailApiModel()
            {
                Name = data.Name,
                Surname = data.Surname,
                Location = data.Location,
                Position = data.Position,
                ProfileImageUrl = data.ProfileImageUrl,
                ProfileImageAltText = data.ProfileImageAltText,
                Url = data.Url
            };
        }

        public static IEnumerable<TeamDetailViewModel> Map(IEnumerable<ItemLinkField<TeamDetail>> data)
        {
            return data.Select(Map);
        }

        public static TeamDetailViewModel Map(ItemLinkField<TeamDetail> data)
        {
            return new TeamDetailViewModel()
            {
                Name = data.Fields?.Name?.Value,
                Surname = data.Fields?.Surname?.Value,
                Email = data.Fields?.Email?.Value?.Href,
                ProfileImageUrl = data.Fields?.ProfileImage?.Value?.Src,
                ProfileImageAltText = data.Fields?.ProfileImage?.Value?.Alt,
                Bio = data.Fields?.Bio?.Value,
                Location = data.Fields?.Location?.Fields?.Title?.Value,
                Position = data.Fields?.Position?.Fields?.Title?.Value
            };
        }
    }
}
