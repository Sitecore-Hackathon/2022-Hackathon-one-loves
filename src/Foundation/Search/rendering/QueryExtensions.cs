using System;
using System.Collections.Generic;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace Hackathon.Foundation.Search
{
    public static class QueryExtensions
    {
        public static List<ISolrQuery> AppendFilters(this List<ISolrQuery> filterQueries, Fields fields)
        {
            if (fields == null)
            {
                return filterQueries;
            }

            if (!string.IsNullOrWhiteSpace(fields.TagName))
            {
                filterQueries.Add(new SolrQueryByField(Constants.BlogPostConstants.TagsName, fields.TagName));
            }
            else if (fields.TagId != Guid.Empty)
            {
                filterQueries.Add(new SolrQueryByField(Constants.BlogPostConstants.TagsId, fields.TagId.ToString("N")));
            }

            if (fields.AuthorId != Guid.Empty)
            {
                filterQueries.Add(new SolrQueryByField(Constants.BlogPostConstants.AuthorId, fields.AuthorId.ToString("N")));
            }

            if (!string.IsNullOrWhiteSpace(fields.TeamDetailName))
            {
                filterQueries.Add(new SolrQueryByField(Constants.TeamDetailConstants.Name, fields.TeamDetailName));
                filterQueries.Add(new SolrQueryByField(Constants.TeamDetailConstants.Surname, fields.TeamDetailName));
            }

            if (fields.TeamLocationId != Guid.Empty && fields.TeamLocationId != Constants.AllLocationsId)
            {
                filterQueries.Add(new SolrQueryByField(Constants.TeamDetailConstants.LocationId, fields.TeamLocationId.ToString("N")));
            }

            if (!string.IsNullOrWhiteSpace(fields.TeamDetailText))
            {
                var fieldValue = $"*{fields.TeamDetailText.Trim()}*";
                // TODO: expand list of searching fields
                var queries = new List<ISolrQuery>()
                {
                    new SolrQueryByField(Constants.TeamDetailConstants.Name, fieldValue),
                    new SolrQueryByField(Constants.TeamDetailConstants.Surname, fieldValue),
                    new SolrQueryByField(Constants.TeamDetailConstants.Bio, fieldValue),
                };

                filterQueries.Add(new SolrMultipleCriteriaQuery(queries, SolrMultipleCriteriaQuery.Operator.OR));
            }

            if (!string.IsNullOrWhiteSpace(fields.JobDetailTitle))
            {
                filterQueries.Add(new SolrQueryByField(Constants.JobDetailConstants.Title, fields.JobDetailTitle));
            }

            if (fields.JobLocationId != Guid.Empty && fields.JobLocationId != Constants.AllLocationsId)
            {
                if (fields.JobLocationId != Constants.AllLocationsId)
                {
                    filterQueries.Add(new SolrQueryByField(Constants.JobDetailConstants.LocationIds, fields.JobLocationId.ToString("N")));
                }
            }

            if (!string.IsNullOrWhiteSpace(fields.JobDetailText))
            {
                filterQueries.Add(new SolrQueryByField(Constants.JobDetailConstants.Title, $"*{fields.JobDetailText.Trim()}*"));
            }

            if (fields.PositionIds != Guid.Empty)
            {
                filterQueries.Add(new SolrQueryByField(Constants.JobDetailConstants.PositionId, fields.PositionIds.ToString("N")));
            }

            if (!string.IsNullOrWhiteSpace(fields.BlogPostText))
            {
                filterQueries.Add(new SolrQueryByField(Constants.BlogPostConstants.BlogPostText, $"*{fields.BlogPostText.Trim()}*"));
            }

            return filterQueries;
        }

        public static QueryOptions AppendPaging(this QueryOptions options, Paging paging)
        {
            if (paging == null)
            {
                return options;
            }

            options.StartOrCursor = new StartOrCursor.Start(paging.StartNumber);
            options.Rows = paging.Count;

            return options;
        }

        public static ICollection<SortOrder> AppendSorting(this ICollection<SortOrder> orderBy, Sorting sorting)
        {
            if (sorting == null)
            {
                return orderBy;
            }

            var direction = sorting.Order == Order.Asc ? SolrNet.Order.ASC : SolrNet.Order.DESC;
            orderBy = new List<SortOrder>()
            {
                new SortOrder(Constants.BlogPostConstants.SortOrder, direction)
            };

            return orderBy;
        }
    }
}