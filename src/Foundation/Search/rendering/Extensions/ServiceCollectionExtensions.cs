using Hackathon.Foundation.Search.Interfaces;
using Hackathon.Foundation.Search.Models;
using Hackathon.Foundation.Search.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SolrNet;

namespace Hackathon.Foundation.Search.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFoundationSolr(this IServiceCollection services, string solrUrl, string indexName, string homeId)
        {
            Settings.HomeId = homeId;

            services
                .AddSolrNet<SearchModel>($"{solrUrl}/{indexName}")
                .AddSolrNet<BlogPostSearchModel>($"{solrUrl}/{indexName}")
                .AddTransient<IBlogPostSolrRepository, BlogPostSolrRepository>()
                .AddSolrNet<TeamDetailSearchModel>($"{solrUrl}/{indexName}")
                .AddTransient<ITeamDetailSolrRepository, TeamDetailSolrRepository>()
                .AddSolrNet<JobDetailSearchModel>($"{solrUrl}/{indexName}")
                .AddTransient<IJobDetailSolrRepository, JobDetailSolrRepository>();
            return services;
        }
    }
}
