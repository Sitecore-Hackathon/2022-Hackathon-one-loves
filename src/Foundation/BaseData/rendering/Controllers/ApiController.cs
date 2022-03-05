using System.Collections.Generic;
using Hackathon.Foundation.Dictionary;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Foundation.BaseData.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        private readonly ISitecoreLocalizer _localizer;

        private Dictionary<string, Dictionary<string, string>> _localizationDictionary;

        protected Dictionary<string, Dictionary<string, string>> LocalizationDictionary => _localizationDictionary ??= _localizer.GetLocalizedValue();

        protected ApiController(ISitecoreLocalizer localizer)
        {
            _localizer = localizer;
        }

        protected string GetDictionaryValue(string language, string key)
        {
            if (LocalizationDictionary.TryGetValue(language, out var dictionary) && dictionary.TryGetValue(key, out var value))
            {
                return value;
            }
            return null;
        }
    }
}
