using System.Collections.Generic;
using System.Globalization;

namespace Hackathon.Feature.Navigation.Models
{
    public class LanguageSwitcherModel
    {
        public CultureInfo CurrentUICulture { get; set; }
        public List<CultureInfo> SupportedCultures { get; set; }
        public string CurrentSitecoreRoute { get; set; }
    }
}
