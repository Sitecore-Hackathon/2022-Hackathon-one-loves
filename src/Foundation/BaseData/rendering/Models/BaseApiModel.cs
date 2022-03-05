using System.Collections.Generic;

namespace Hackathon.Foundation.BaseData.Models
{
    public class BaseApiModel<T>
    {
        public IEnumerable<T> Items { get; set; }

        public bool ShowLoadMore { get; set; }
    }
}
