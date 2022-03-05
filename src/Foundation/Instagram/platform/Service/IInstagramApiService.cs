using System.Collections.Generic;

namespace Hackathon.Foundation.Instagram.Service
{
    public interface IInstagramApiService
    {
        List<string> GetMediaList();
        string RefreshAccessToken();
    }
}