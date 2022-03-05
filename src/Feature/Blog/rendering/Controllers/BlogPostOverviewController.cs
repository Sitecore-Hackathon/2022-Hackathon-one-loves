using System.Linq;
using Hackathon.Feature.Blog.Helpers;
using Hackathon.Feature.Blog.Models.ApiModel;
using Hackathon.Foundation.BaseData.Controllers;
using Hackathon.Foundation.BaseData.Models;
using Hackathon.Foundation.Dictionary;
using Hackathon.Foundation.Search;
using Hackathon.Foundation.Search.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hackathon.Feature.Blog.Controllers
{
    [ApiController]
    [Route("api/getblogposts")]
    public class BlogPostOverviewController : ApiController
    {
        private readonly IBlogPostSolrRepository _blogPostSolrRepository;

        public BlogPostOverviewController(IBlogPostSolrRepository blogPostSolrRepository, ISitecoreLocalizer localizer) : base(localizer)
        {
            _blogPostSolrRepository = blogPostSolrRepository;
        }

        [HttpGet]
        public ActionResult<string> Get([FromQuery] string tag, [FromQuery] string text, [FromQuery] string language, [FromQuery] int pageNumber, [FromQuery] int count)
        {
            var parameters = new SearchParameters()
            {
                Fields = new Fields()
                {
                    Language = language,
                    TagName = tag,
                    BlogPostText = text
                },
                Paging = new Paging()
                {
                    PageNumber = pageNumber,
                    Count = count
                }
            };

            var result = _blogPostSolrRepository.GetBlogPosts(parameters);

            var apiModel = new BaseApiModel<BlogPostApiItemModel>()
            {
                ShowLoadMore = result.NumFound > ((pageNumber + 1) * count),
                Items = BlogPostHelper.Map(result)
                    .Select(m =>
                    {
                        var model = BlogPostHelper.Map(m);
                        model.LearnMoreText = GetDictionaryValue(language, "Learn More");
                        return model;
                    })
            };

            return JsonConvert.SerializeObject(apiModel);
        }
    }
}
