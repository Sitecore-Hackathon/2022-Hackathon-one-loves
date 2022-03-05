using Hackathon.Foundation.Search.Models;
using System.Collections.Generic;
using SolrNet;

namespace Hackathon.Foundation.Search.Interfaces
{
    public interface ITeamDetailSolrRepository
    {
        public IEnumerable<TeamDetailSearchModel> GetRandomTeamDetails(int count);
        public SolrQueryResults<TeamDetailSearchModel> GetTeamDetails(SearchParameters parameters);
    }
}
