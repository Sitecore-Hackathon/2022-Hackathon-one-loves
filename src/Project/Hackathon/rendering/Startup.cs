using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sitecore.AspNet.ExperienceEditor;
using Sitecore.AspNet.RenderingEngine.Extensions;
using Sitecore.AspNet.RenderingEngine.Localization;
using Sitecore.AspNet.Tracking;
using Sitecore.LayoutService.Client.Extensions;
using Sitecore.LayoutService.Client.Newtonsoft.Extensions;
using Sitecore.LayoutService.Client.Request;
using Hackathon.Feature.BasicContent.Extensions;
using Hackathon.Feature.Blog.Extensions;
using Hackathon.Feature.Career.Extensions;
using Hackathon.Feature.Hero.Extensions;
using Hackathon.Feature.Navigation.Extensions;
using Hackathon.Project.Website.Rendering.Configuration;
using Hackathon.Feature.Service.Extensions;
using Hackathon.Feature.Team.Extensions;
using Hackathon.Foundation.BasicContent.Extensions;
using Hackathon.Foundation.Dictionary;
using Hackathon.Foundation.Dictionary.Extensions;
using Microsoft.Extensions.Logging;
using Hackathon.Foundation.Search.Extensions;

namespace Hackathon.Project.Website.Rendering
{
    public class Startup
    {
        private static readonly string _defaultLanguage = "en";
        private static readonly List<CultureInfo> _supportedCultures = new List<CultureInfo> { new CultureInfo(_defaultLanguage), new CultureInfo("de-DE") };

        public Startup(IConfiguration configuration)
        {
            // Example of using ASP.NET Core configuration binding for various Sitecore Rendering Engine settings.
            // Values can originate in appsettings.json, from environment variables, and more.
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-3.1
            Configuration = configuration.GetSection(SitecoreOptions.Key).Get<SitecoreOptions>();
        }

        private SitecoreOptions Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddFoundationSolr(Configuration.SolrUrl, Configuration.IndexName, Configuration.HomeId)
                .AddRouting()
                // You must enable ASP.NET Core localization to utilize localized Sitecore content.
                .AddLocalization(options => options.ResourcesPath = "Resources")
                .AddMvc()
                // At this time the Layout Service Client requires Json.NET due to limitations in System.Title.Json.
                .AddNewtonsoftJson(o => o.SerializerSettings.SetDefaults());

            // Register the Sitecore Layout Service Client, which will be invoked by the Sitecore Rendering Engine.
            services.AddSitecoreLayoutService()
                // Set default parameters for the Layout Service Client from our bound configuration object.
                .WithDefaultRequestOptions(request =>
                {
                    request
                        .SiteName(Configuration.DefaultSiteName)
                        .ApiKey(Configuration.ApiKey);
                })
                .AddHttpHandler("default", Configuration.LayoutServiceUri)
                .AsDefaultHandler();

            // Register the Sitecore Rendering Engine services.
            services.AddSitecoreRenderingEngine(options =>
            {
                //Register your components here
                options
                    .AddFeatureBasicContent()
                    .AddFeatureBlog()
                    .AddFeatureCareer()
                    .AddFeatureNavigation()
                    .AddFeatureTeam()
                    .AddFeatureHero()
                    .AddFeatureService()
                    .AddDefaultPartialView("_ComponentNotFound");
            })
                // Includes forwarding of Scheme as X-Forwarded-Proto to the Layout Service, so that
                // Sitecore Media and other links have the correct scheme.
                .ForwardHeaders()
                // Enable forwarding of relevant headers and client IP for Sitecore Tracking and Personalization.
                .WithTracking()
                // Enable support for the Experience Editor.
                .WithExperienceEditor();

            // Enable support for robot detection.
            services.AddSitecoreVisitorIdentification(options =>
            {
                // Usually the SitecoreInstanceUri is same host as the Layout Service, but it can be any Sitecore CD/CM
                // instance which shares same AspNet session with Layout Service. This address should be accessible
                // from the Rendering Host and will be used to proxy robot detection scripts.
                options.SitecoreInstanceUri = Configuration.InstanceUri;
            });

            // You need to configure localization options here so you can access them in your language switcher component
            services.Configure<RequestLocalizationOptions>(options =>
            {
                // If you add languages in Sitecore that this site/rendering host should support, then add them here.
                options.DefaultRequestCulture = new RequestCulture(_defaultLanguage, _defaultLanguage);
                options.SupportedCultures = _supportedCultures;
                options.SupportedUICultures = _supportedCultures;

                // Resolve culture through the standard Sitecore URL prefix and query string (sc_lang).
                options.UseSitecoreRequestLocalization();
            });

            services.AddFoundationDictionary(_supportedCultures, Configuration.DictionaryServiceUri);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            // When running behind HTTPS termination, set the request scheme according to forwarded protocol headers.
            // Also set the Request IP, so that it can be passed on to the Sitecore Layout Service for tracking and personalization.
            app.UseForwardedHeaders(ConfigureForwarding(env));

            app.AddFeatureBlog();
            app.AddFoundationDictionary();
            app.AddFoundationBasicContent();

            logger.LogInformation("STARTUP LOG: IsDevelopment() = " + env.IsDevelopment());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            logger.LogInformation("STARTUP LOG: Configuration.EnableExperienceEditor = " + Configuration.EnableExperienceEditor);
            // The Experience Editor endpoint should not be enabled in production DMZ.
            // See the SDK documentation for details.
            if (Configuration.EnableExperienceEditor)
            {
                // Enable the Sitecore Experience Editor POST endpoint.
                app.UseSitecoreExperienceEditor();
            }

            // Standard ASP.NET Core routing and static file support.
            app.UseRouting();
            app.UseStaticFiles();

            // Enable ASP.NET Core Localization, which is required for Sitecore content localization.
            app.UseRequestLocalization();

            // Enable proxying of Sitecore robot detection scripts
            app.UseSitecoreVisitorIdentification();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "error",
                    "error",
                    new { controller = "Default", action = "Error" }
                );

                endpoints.AddFoundationDictionary();

                // Enables the default Sitecore URL pattern with a language prefix.
                endpoints.MapSitecoreLocalizedRoute("sitecore", "Index", "Default");

                // Fall back to language-less routing as well, and use the default culture (en).
                endpoints.MapFallbackToController("Index", "Default");
            });

            //Task.Run(async () => await app.ApplicationServices.GetRequiredService<ISitecoreLocalizer>().Reload()).Wait();
        }

        private ForwardedHeadersOptions ConfigureForwarding(IWebHostEnvironment env)
        {
            var options = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            };
            if (env.IsDevelopment())
            {
                // Allow forwarding of headers from Traefik in development
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            }
            // ReSharper disable once RedundantIfElseBlock
            else
            {
                // TODO: You should configure forwarding options here appropriately based on your test/production environments.
                // https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/proxy-load-balancer?view=aspnetcore-3.1
            }

            return options;
        }
    }

}
