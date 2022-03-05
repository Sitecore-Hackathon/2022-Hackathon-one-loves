using Hackathon.Feature.Team.Models;
using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNet.RenderingEngine.Binding;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Feature.Team.Models.ViewModels;
using Hackathon.Foundation.Search.Interfaces;

namespace Hackathon.Feature.Team.ViewComponents
{
    public class TeamSectionViewComponent : ViewComponent
    {
        private readonly IViewModelBinder _modelBinder;
        private readonly ITeamDetailSolrRepository _teamDetailSolrRepository;

        public TeamSectionViewComponent(IViewModelBinder modelBinder, ITeamDetailSolrRepository teamDetailSolrRepository)
        {
            _teamDetailSolrRepository = teamDetailSolrRepository;
            _modelBinder = modelBinder;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _modelBinder.Bind<TeamSection>(this.ViewContext);

            var viewModel = new TeamSectionViewModel()
            {
                Headline = model.Headline?.Value,
                LinkUrl = model.Link?.Value?.Href,
                LinkText = model.Link?.Value?.Text
            };

            if (model.IsRandom != null && !model.IsRandom.Value)
            {
                viewModel.Team = model.Team.Select(x => new TeamDetailViewModel()
                {
                    Name = x.Fields?.Name?.Value,
                    Url = x.Url,
                    ProfileImageUrl = x.Fields?.ProfileImage.Value.Src,
                    ProfileImageAltText = x.Fields?.ProfileImage.Value.Alt
                });
            }
            else
            {
                var team = _teamDetailSolrRepository.GetRandomTeamDetails(6).ToList();

                if (team.Any())
                {
                    viewModel.Team = team.Select(x => new TeamDetailViewModel()
                    {
                        Name = x.Name,
                        Url = x.Url,
                        ProfileImageUrl = x.ProfileImageUrl,
                        ProfileImageAltText = x.ProfileImageAltText
                    });
                }
            }

            return View(viewModel);
        }
    }
}
