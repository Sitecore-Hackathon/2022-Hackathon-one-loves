using System.Linq;
using System.Threading.Tasks;
using Hackathon.Feature.Navigation.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Hackathon.Feature.Navigation.ViewComponents
{
    public class LanguageSwitcherViewComponent : ViewComponent
    {
        private readonly IOptions<RequestLocalizationOptions> _localizationOptions;

        public LanguageSwitcherViewComponent(IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _localizationOptions = localizationOptions;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var languageSwitcherModel = new LanguageSwitcherModel
            {
                SupportedCultures = _localizationOptions.Value.SupportedCultures.ToList(),
                CurrentUICulture = cultureFeature.RequestCulture.Culture,
                CurrentSitecoreRoute = this.HttpContext.Request.RouteValues["sitecoreRoute"]?.ToString() ?? ""
            };
            return View(languageSwitcherModel);
        }
    }
}
