using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Foundation.Dictionary.Controllers
{
    public class LocalizationController : ControllerBase
    {
        private readonly ISitecoreLocalizer _sitecoreLocalizer;

        public LocalizationController(ISitecoreLocalizer sitecoreLocalizer)
        {
            _sitecoreLocalizer = sitecoreLocalizer;
        }

        [HttpPost]
        public IActionResult Reload()
        {
            _sitecoreLocalizer.Reload();
            return Ok();
        }
    }
}
