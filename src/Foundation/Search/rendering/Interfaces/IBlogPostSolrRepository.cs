using Hackathon.Foundation.Search.Models;
using SolrNet;

namespace Hackathon.Foundation.Search.Interfaces
{
    public interface IBlogPostSolrRepository
    {
        public SolrQueryResults<BlogPostSearchModel> GetBlogPosts(SearchParameters parameters);
    }
}
