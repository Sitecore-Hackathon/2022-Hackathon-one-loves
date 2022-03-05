using Hackathon.Foundation.Search.Models;
using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using Hackathon.Foundation.Search.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Hackathon.Foundation.Search.Repositories
{
    public class TeamDetailSolrRepository : BaseSolrRepository, ITeamDetailSolrRepository
    {
        private readonly ISolrBasicReadOnlyOperations<TeamDetailSearchModel> _solr;

        public TeamDetailSolrRepository(ISolrBasicReadOnlyOperations<TeamDetailSearchModel> solr, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _solr = solr;
        }

        public IEnumerable<TeamDetailSearchModel> GetRandomTeamDetails(int count)
        {
            var filterQueries = InitializeFilters();

            var options = new QueryOptions
            {
                FilterQueries = filterQueries
            };
            var result = _solr.Query(SolrQuery.All, options);

            return result.OrderBy(x => Guid.NewGuid()).Take(count);
        }

        public SolrQueryResults<TeamDetailSearchModel> GetTeamDetails(SearchParameters parameters)
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

        private List<ISolrQuery> InitializeFilters(string language = null)
        {
            return InitFilters(new SolrQueryByField(Constants.Template, Templates.TeamDetailPage.Id), language);
        }
    }
}