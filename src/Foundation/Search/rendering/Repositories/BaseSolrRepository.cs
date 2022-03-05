using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Sitecore.AspNet.RenderingEngine;
using SolrNet;

namespace Hackathon.Foundation.Search.Repositories
{
    public class BaseSolrRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private string Language =>
            _httpContextAccessor.HttpContext.Features.Get<ISitecoreRenderingContext>()?.Response?.Content
                ?.Sitecore?.Context?.Language;

        public BaseSolrRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected List<ISolrQuery> InitFilters(ISolrQuery query, string language = null)
        {
            var initFilters = new List<ISolrQuery>
            {
                new SolrQueryByField(Constants.Path, Settings.HomeIdDigits),
                query
            };
            if (!string.IsNullOrWhiteSpace(language))
            {
                initFilters.Add(new SolrQueryByField(Constants.Language, language));
            }
            else if (!string.IsNullOrWhiteSpace(Language))
            {
                initFilters.Add(new SolrQueryByField(Constants.Language, Language));
            }

            return initFilters;
        }
    }
}
