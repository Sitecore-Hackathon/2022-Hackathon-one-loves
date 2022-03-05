using System.Linq;
using System.Threading.Tasks;
using Hackathon.Feature.Blog.Helpers;
using Hackathon.Feature.Blog.Models;
using Hackathon.Feature.Blog.Models.ViewModels;
using Hackathon.Foundation.Search;
using Hackathon.Foundation.Search.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNet.RenderingEngine.Binding;

namespace Hackathon.Feature.Blog.ViewComponents
{
    public class BlogPostSuggestionViewComponent : ViewComponent
    {
        private readonly IViewModelBinder _modelBinder;
        private readonly IBlogPostSolrRepository _blogPostSolrRepository;

        public BlogPostSuggestionViewComponent(IViewModelBinder modelBinder, IBlogPostSolrRepository blogPostSolrRepository)
        {
            _blogPostSolrRepository = blogPostSolrRepository;
            _modelBinder = modelBinder;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _modelBinder.Bind<BlogPostSuggestion>(this.ViewContext);
            var viewModel = new BlogPostSuggestionViewModel()
            {
                Headline = model.Headline?.Value,
                BlogKeywordPageUrl = model.BlogKeywordPage?.Fields?.Link?.Value?.Href
            };

            var parameters = new SearchParameters();
            if (model.Posts != null && model.Posts.Any())
            {
                viewModel.Posts = BlogPostHelper.Map(model.Posts?.Take(3));
            }
            else if (model.Tags != null && model.Tags.Any())
            {
                var tag = model.Tags.First();

                parameters.Fields = new Fields {TagId = tag.Id};
                var data = _blogPostSolrRepository.GetBlogPosts(parameters);

                viewModel.Posts = BlogPostHelper.Map(data);
            }
            else if (model.Author != null)
            {
                parameters.Fields = new Fields {AuthorId = model.Author.Id};
                var data = _blogPostSolrRepository.GetBlogPosts(parameters);

                viewModel.Posts = BlogPostHelper.Map(data);
            }

            return View(viewModel);
        }
    }
}