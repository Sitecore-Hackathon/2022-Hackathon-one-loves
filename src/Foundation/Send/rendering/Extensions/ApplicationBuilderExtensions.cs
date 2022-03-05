using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Hackathon.Foundation.Send.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IEndpointRouteBuilder AddFoundationSend(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                "track",
                "api/track/{action=event}",
                new { controller = "Track", action = "Event" }
            );
            return endpoints;
        }
    }
}
