using Hackathon.Foundation.Search.Models;
using Microsoft.AspNetCore.Http;
using SolrNet;
using SolrNet.Commands.Parameters;
using System.Collections.Generic;
using Hackathon.Foundation.Search.Interfaces;

namespace Hackathon.Foundation.Search.Repositories
{
    public class BlogPostSolrRepository : BaseSolrRepository, IBlogPostSolrRepository
    {
        private readonly ISolrBasicReadOnlyOperations<BlogPostSearchModel> _solr;

        public BlogPostSolrRepository(ISolrBasicReadOnlyOperations<BlogPostSearchModel> solr, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _solr = solr;
        }

        public SolrQueryResults<BlogPostSearchModel> GetBlogPosts(SearchParameters parameters)
        {
            var filterQueries = InitializeFilters(parameters.Fields?.Language);
            filterQueries.AppendFilters(parameters.Fields);

            var options = new QueryOptions
            {
                FilterQueries = filterQueries
            };

            options.AppendPaging(parameters.Paging);
            options.OrderBy.AppendSorting(parameters.Sorting);

            var result = _solr.Query(SolrQuery.All, options);
            return result;
        }

        private List<ISolrQuery> InitializeFilters(string language)
        {
            return InitFilters(new SolrQueryByField(Constants.Template, Templates.BlogPostPage.Id), language);
        }
    }
}