using System;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Feature.Blog.Helpers;
using Hackathon.Feature.Blog.Models;
using Hackathon.Feature.Blog.Models.ViewModels;
using Hackathon.Foundation.Search;
using Hackathon.Foundation.Search.Repositories;
using Hackathon.Foundation.Search.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNet.RenderingEngine.Binding;

namespace Hackathon.Feature.Blog.ViewComponents
{
    public class BlogPostOverviewViewComponent : ViewComponent
    {
        private readonly IViewModelBinder _modelBinder;
        private readonly IBlogPostSolrRepository _blogPostSolrRepository;

        public BlogPostOverviewViewComponent(IViewModelBinder modelBinder, IBlogPostSolrRepository blogPostSolrRepository)
        {
            _modelBinder = modelBinder;
            _blogPostSolrRepository = blogPostSolrRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _modelBinder.Bind<BlogPostOverview>(this.ViewContext);

            var viewModel = new BlogPostOverviewViewModel()
            {
                Headline = model.Headline?.Value,
                NumberOfTags = Convert.ToInt32(model.NumberOfTags?.Value),
                BlogKeywordPageUrl = model.BlogKeywordPage?.Fields?.Link?.Value?.Href, 
                SelectedTag = model.SelectedTag?.Fields?.Title?.Value.ToLower()
            };

            var viewModelShowLoadMore = string.Empty;
            model.Parameters?.TryGetValue("ShowLoadMore", out viewModelShowLoadMore);
            viewModel.ShowLoadMore = viewModelShowLoadMore == "1";

            var viewModelShowGoToAll = string.Empty;
            model.Parameters?.TryGetValue("ShowGoToAll", out viewModelShowGoToAll);
            viewModel.ShowGoToAll = viewModelShowGoToAll == "1";

            var viewModelSortAsc = string.Empty;
            model.Parameters?.TryGetValue("SortAsc", out viewModelSortAsc);

            var numberOfPosts = Convert.ToInt32(model.NumberOfPosts?.Value ?? 9);

            var fields = new Fields();
            if (this.HttpContext.Request.Query.TryGetValue("tag", out var tagName) && !string.IsNullOrWhiteSpace(tagName))
            {
                fields.TagName = tagName;
            }
            if (!string.IsNullOrEmpty(viewModel.SelectedTag))
            {
                fields.TagName = viewModel.SelectedTag;
            }

            var parameters = new SearchParameters
            {
                Paging = new Paging() { PageNumber = 0, Count = numberOfPosts },
                Fields = fields,
                Sorting = new Sorting { Order = viewModelSortAsc == "1" ? Order.Asc : Order.Desc }
            };

            var posts = _blogPostSolrRepository.GetBlogPosts(parameters);
            viewModel.Posts = posts.Select(BlogPostHelper.Map);

            return View(viewModel);
        }
    }
}
