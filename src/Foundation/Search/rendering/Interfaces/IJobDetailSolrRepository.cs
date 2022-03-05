using Hackathon.Foundation.Search.Models;
using SolrNet;

namespace Hackathon.Foundation.Search.Interfaces
{
    public interface IJobDetailSolrRepository
    {
        public SolrQueryResults<JobDetailSearchModel> GetJobDetails(SearchParameters parameters);
    }
}
