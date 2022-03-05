using System;
using Newtonsoft.Json;

namespace Hackathon.Foundation.Instagram.Models
{
    public class MediaList
    {
        [JsonProperty("data")]
        public MediaItem[] Data { get; set; }
        
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }

    public class MediaItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }
    }

    public class Paging
    {
        [JsonProperty("cursors")]
        public Cursors Cursors { get; set; }
    }

    public class Cursors
    {
        [JsonProperty("before")]
        public string Before { get; set; }

        [JsonProperty("after")]
        public string After { get; set; }
    }
}