using Hackathon.Foundation.Search.Models;
using SolrNet;
using SolrNet.Commands.Parameters;
using System.Collections.Generic;
using Hackathon.Foundation.Search.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Hackathon.Foundation.Search.Repositories
{
    public class JobDetailSolrRepository : BaseSolrRepository, IJobDetailSolrRepository
    {
        private readonly ISolrBasicReadOnlyOperations<JobDetailSearchModel> _solr;

        public JobDetailSolrRepository(ISolrBasicReadOnlyOperations<JobDetailSearchModel> solr, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _solr = solr;
        }

        public SolrQueryResults<JobDetailSearchModel> GetJobDetails(SearchParameters parameters)
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
            return InitFilters(new SolrQueryByField(Constants.Template, Templates.JobDetailPage.Id), language);
        }
    }
}