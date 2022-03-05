using Hackathon.Feature.Services.Models;
using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Hackathon.Feature.Products.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureServices(this RenderingEngineOptions options)
        {
            options
                .AddPartialView("TestimonialContainer")
                .AddModelBoundView<Testimonial>("Testimonial");
            return options;
        }
    }
}
