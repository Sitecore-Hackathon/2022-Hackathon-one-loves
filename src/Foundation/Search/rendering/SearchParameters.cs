using System;
using System.Collections.Generic;

namespace Hackathon.Foundation.Search
{
    public class SearchParameters
    {
        public Fields Fields { get; set; }
        public Paging Paging { get; set; }
        public Sorting Sorting { get; set; }
    }

    public class Fields
    {
        public string Language { get; set; }

        public string BlogPostText { get; set; }

        public Guid TagId { get; set; }
        public string TagName { get; set; }

        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }

        public string TeamDetailName { get; set; }

        public string TeamDetailText { get; set; }

        public string JobDetailTitle { get; set; }

        public string JobDetailText { get; set; }

        public Guid TeamLocationId { get; set; }

        public Guid JobLocationId { get; set; }

        public Guid PositionIds { get; set; }
    }

    public class Paging
    {
        public int PageNumber { get; set; }
        public int Count { get; set; }
        public int StartNumber => PageNumber * Count;
    }

    public class Sorting
    {
        public Order Order { get; set; }
    }
    public enum Order
    {
        Asc,
        Desc
    }
}
