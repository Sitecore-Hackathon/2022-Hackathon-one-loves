using System;

namespace Hackathon.Foundation.Search
{
    public static class Settings
    {
        public static string HomeId { get; set; }

        private static string _homeIdDigits;

        public static string HomeIdDigits
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_homeIdDigits))
                {
                    return _homeIdDigits;
                }

                Guid.TryParse(HomeId, out var homeGuid);
                _homeIdDigits =  homeGuid.ToString("N");
                return _homeIdDigits;
            }
        }
    }
}
