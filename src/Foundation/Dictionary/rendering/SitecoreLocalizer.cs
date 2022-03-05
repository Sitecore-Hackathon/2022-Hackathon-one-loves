using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Hackathon.Foundation.Dictionary
{
    public class SitecoreLocalizer : ISitecoreLocalizer
    {
        private static readonly Dictionary<string, Dictionary<string, string>> SitecoreDictionary = new Dictionary<string, Dictionary<string, string>>();
        private readonly HttpClient _httpClient;
        private readonly SitecoreLocalizerOptions _sitecoreLocalizerOptions;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SitecoreLocalizer(
            IHttpClientFactory httpClientFactory,
            IOptions<SitecoreLocalizerOptions> sitecoreLocalizerOptions,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _httpClient = httpClientFactory.CreateClient("sitecoreLocalizer");
            _sitecoreLocalizerOptions = sitecoreLocalizerOptions?.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        private string RequestCulture => _httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.ToString();


        public LocalizedString this[string name] => GetDictionaryValue(name);

        public LocalizedString this[string name, params object[] arguments] => GetDictionaryValue(name, arguments);

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            if (!SitecoreDictionary.TryGetValue(RequestCulture, out var dictionaryItems))
            {
                return null;
            }

            var localizedStrings = dictionaryItems
                .Select(item => new LocalizedString(item.Key, item.Value));
            return localizedStrings;
        }

        public Dictionary<string, Dictionary<string, string>> GetLocalizedValue()
        {
            var dictionary = new Dictionary<string, Dictionary<string, string>>();
            foreach (var culture in _sitecoreLocalizerOptions.Cultures)
            {
                var key = culture.ToString();
                var requestUri = _httpClient.BaseAddress.AbsoluteUri.Replace("[language]", key);

                var response = _httpClient.GetAsync(requestUri).Result;
                if (!response.IsSuccessStatusCode)
                {
                    continue;
                }

                var content = response.Content.ReadAsStringAsync().Result;
                dictionary[key] = JsonConvert.DeserializeObject<DictionaryModel>(content)?.Phrases;
            }

            return dictionary;
        }

        public async Task Reload()
        {
            foreach (var culture in _sitecoreLocalizerOptions.Cultures)
            {
                var key = culture.ToString();
                var requestUri = _httpClient.BaseAddress.AbsoluteUri.Replace("[language]", key);

                var response = await _httpClient.GetAsync(requestUri);
                if (!response.IsSuccessStatusCode)
                {
                    continue;
                }

                var content = await response.Content.ReadAsStringAsync();
                SitecoreDictionary[key] = JsonConvert.DeserializeObject<DictionaryModel>(content)?.Phrases;
            }
        }

        private LocalizedString GetDictionaryValue(string name)
        {
            if (!SitecoreDictionary.TryGetValue(RequestCulture, out var dictionary))
            {
                return null;
            }
            if (!dictionary.TryGetValue(name, out var value))
            {
                return null;
            }
            var dictionaryValue = new LocalizedString(name, value);
            return dictionaryValue;
        }

        private LocalizedString GetDictionaryValue(string name, params object[] arguments)
        {
            if (!SitecoreDictionary.TryGetValue(RequestCulture, out var dictionary))
            {
                return null;
            }
            if (!dictionary.TryGetValue(name, out var value))
            {
                return null;
            }
            var format = string.Format(value, arguments);
            var dictionaryValue = new LocalizedString(name, format);
            return dictionaryValue;
        }

        [Obsolete]
        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
