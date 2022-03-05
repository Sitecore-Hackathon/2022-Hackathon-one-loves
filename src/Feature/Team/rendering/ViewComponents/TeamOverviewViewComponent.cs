using System;
using Hackathon.Feature.Team.Models;
using Hackathon.Feature.Team.Models.ViewModels;
using Hackathon.Foundation.Search;
using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNet.RenderingEngine.Binding;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Feature.Team.Helpers;
using Hackathon.Foundation.Search.Interfaces;

namespace Hackathon.Feature.Team.ViewComponents
{
    public class TeamOverviewViewComponent : ViewComponent
    {
        private readonly IViewModelBinder _modelBinder;
        private readonly ITeamDetailSolrRepository _teamDetailSolrRepository;

        public TeamOverviewViewComponent(IViewModelBinder modelBinder,
            ITeamDetailSolrRepository teamDetailSolrRepository)
        {
            _teamDetailSolrRepository = teamDetailSolrRepository;
            _modelBinder = modelBinder;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _modelBinder.Bind<TeamOverview>(this.ViewContext);

            var viewModel = new TeamOverviewViewModel
            {
                Locations = model.Locations.Select(l =>
                    new LocationViewModel
                    {
                        Id = l.Id,
                        Title = l.Fields?.Title?.Value,
                        IsClearSelection = l.Fields?.ClearSelection?.Value ?? false
                    })
            };

            var numberOfPosts = Convert.ToInt32(model.NumberOfMembers?.Value ?? 9);

            var parameters = new SearchParameters
            {
                Paging = new Paging() { PageNumber = 0, Count = numberOfPosts }
            };

            var posts = _teamDetailSolrRepository.GetTeamDetails(parameters);
            viewModel.TeamDetails = posts.Select(TeamDetailHelper.Map);

            return View(viewModel);
        }
    }
}
