using System;
using System.Linq;
using Hackathon.Feature.Team.Helpers;
using Hackathon.Feature.Team.Models.ViewModels;
using Hackathon.Foundation.BaseData.Controllers;
using Hackathon.Foundation.BaseData.Models;
using Hackathon.Foundation.Dictionary;
using Hackathon.Foundation.Search;
using Hackathon.Foundation.Search.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hackathon.Feature.Team.Controllers
{
    [ApiController]
    [Route("api/getteamdetails")]
    public class TeamOverviewController : ApiController
    {
        private readonly ITeamDetailSolrRepository _teamDetailSolrRepository;

        public TeamOverviewController(ITeamDetailSolrRepository teamDetailSolrRepository, ISitecoreLocalizer localizer) : base(localizer)
        {
            _teamDetailSolrRepository = teamDetailSolrRepository;
        }

        [HttpGet]
        public ActionResult<string> Get([FromQuery] string location, [FromQuery] string text, [FromQuery] string language, [FromQuery] int pageNumber, [FromQuery] int count)
        {
            var parameters = new SearchParameters()
            {
                Fields = new Fields()
                {
                    Language = language,
                    TeamDetailText = text
                },
                Paging = new Paging()
                {
                    PageNumber = pageNumber,
                    Count = count
                }
            };
            if (Guid.TryParse(location, out var guid))
            {
                parameters.Fields.TeamLocationId = guid;
            }
            var result = _teamDetailSolrRepository.GetTeamDetails(parameters);

            var apiModel = new BaseApiModel<TeamDetailViewModel>()
            {
                ShowLoadMore = result.NumFound > ((pageNumber + 1) * count),
                Items = TeamDetailHelper.Map(result)
                    .Select(m =>
                    {
                        var model = TeamDetailHelper.Map(m);
                        model.LearnMoreText = GetDictionaryValue(language, "Learn More");
                        return model;
                    })
            };

            return JsonConvert.SerializeObject(apiModel);
        }
    }
}
