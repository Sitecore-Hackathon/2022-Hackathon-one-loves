using System.Threading.Tasks;
using Hackathon.Feature.Blog.Models.ViewModels;
using Hackathon.Foundation.Search;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Feature.Blog.ViewComponents
{
    public class BlogKeywordViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var fields = new Fields();
            if (this.HttpContext.Request.Query.TryGetValue("tag", out var tagName) && !string.IsNullOrWhiteSpace(tagName))
            {
                fields.TagName = tagName;
            }

            var viewModel = new BlogKeywordViewModel {TagName = tagName};

            return View(viewModel);
        }
    }
}
