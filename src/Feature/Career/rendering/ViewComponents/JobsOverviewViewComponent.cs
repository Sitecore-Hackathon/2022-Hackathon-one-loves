using Hackathon.Feature.Career.Helpers;
using Hackathon.Feature.Career.Models;
using Hackathon.Feature.Career.Models.ViewModels;
using Hackathon.Foundation.Search;
using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNet.RenderingEngine.Binding;
using System;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Foundation.Search.Interfaces;

namespace Hackathon.Feature.Career.ViewComponents
{
    public class JobsOverviewViewComponent : ViewComponent
    {
        private readonly IViewModelBinder _modelBinder;
        private readonly IJobDetailSolrRepository _jobDetailSolrRepository;

        public JobsOverviewViewComponent(IViewModelBinder modelBinder,
            IJobDetailSolrRepository jobDetailSolrRepository)
        {
            _jobDetailSolrRepository = jobDetailSolrRepository;
            _modelBinder = modelBinder;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _modelBinder.Bind<JobsOverview>(this.ViewContext);

            var viewModel = new JobsOverviewViewModel()
            {
                Locations = model.Locations.Select(l =>
                    new LocationViewModel
                    {
                        Id = l.Id,
                        Title = l.Fields?.Title?.Value,
                        IsClearSelection = l.Fields?.ClearSelection?.Value ?? false
                    }),
                Positions = model.Positions.Select(l =>
                    new PositionViewModel()
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

            var posts = _jobDetailSolrRepository.GetJobDetails(parameters);
            viewModel.JobDetails = posts.Select(JobDetailHelper.Map);

            return View(viewModel);
        }
    }
}
