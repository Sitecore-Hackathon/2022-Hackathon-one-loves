using Hackathon.Foundation.Instagram.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Sitecore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace Hackathon.Foundation.Instagram.Service
{
    public class InstagramApiService : IInstagramApiService
    {
        private readonly InstagramSettings _instagramSettings;
        private readonly IMemoryCache _cache;

        public InstagramApiService(IMemoryCache memoryCache)
        {
            _cache = memoryCache;

            var instagramSettings = Context.Database.Items.GetItem(Templates.InstagramSettings.Id);

            if (!int.TryParse(instagramSettings["ImagesCount"], out var imagesCount))
                imagesCount = 5;

            _instagramSettings = new InstagramSettings()
            {
                AccessToken = instagramSettings["AccessToken"],
                ImagesCount = imagesCount
            };
        }

        public List<string> GetMediaList()
        {
            if (!_cache.TryGetValue(new { _instagramSettings.AccessToken, _instagramSettings.ImagesCount }, out string resultJson))
            {
                var request = (HttpWebRequest)WebRequest.Create(
                    $"https://graph.instagram.com/me/media?fields=id,media_type,media_url&access_token={_instagramSettings.AccessToken}");

                using (var response = (HttpWebResponse)request.GetResponse())

                using (var stream = response.GetResponseStream())
                    if (stream != null)
                        using (var reader = new StreamReader(stream))
                        {
                            resultJson = reader.ReadToEnd();
                        }

                if (!string.IsNullOrEmpty(resultJson))
                    _cache.Set(new { _instagramSettings.AccessToken, _instagramSettings.ImagesCount }, resultJson,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(20)));
            }
            var result = JsonConvert.DeserializeObject<MediaList>(resultJson);

            var resultSet = result.Data
                .Where(m => m.MediaType.Equals("IMAGE"))
                .Take(_instagramSettings.ImagesCount)
                .Select(m => m.MediaUrl).ToList();

            return resultSet;
        }

        public string RefreshAccessToken()
        {
            var resultJson = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(
                $"https://graph.instagram.com/refresh_access_token?grant_type=ig_refresh_token&access_token={_instagramSettings.AccessToken}");

            using (var response = (HttpWebResponse)request.GetResponse())

            using (var stream = response.GetResponseStream())
                if (stream != null)
                    using (var reader = new StreamReader(stream))
                    {
                        resultJson = reader.ReadToEnd();
                    }

            var result = JsonConvert.DeserializeObject<RefreshTokenResult>(resultJson);

            var instagramSettings = Context.Database.Items.GetItem(Templates.InstagramSettings.Id);

            instagramSettings.Editing.BeginEdit();
            instagramSettings["AccessToken"] = _instagramSettings.AccessToken = result.AccessToken;
            instagramSettings.Editing.EndEdit();

            return result.AccessToken;
        }
    }
}