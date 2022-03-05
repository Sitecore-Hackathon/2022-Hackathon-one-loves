using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace Hackathon.Foundation.Dictionary
{
    public interface ISitecoreLocalizer : IStringLocalizer
    {
        Dictionary<string, Dictionary<string, string>> GetLocalizedValue();

        Task Reload();
    }
}