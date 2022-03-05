using Sitecore;
using Sitecore.Data;
using Sitecore.LayoutService.Configuration;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hackathon.Feature.BasicContent.LayoutService
{
    public class CssClassContentsResolver : Sitecore.LayoutService.ItemRendering.ContentsResolvers.RenderingContentsResolver
    {
        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var item = GetContextItem(rendering, renderingConfig) ?? Context.Item;

            var result = ProcessItem(item, rendering, renderingConfig);

            var parametersDictionary = rendering.Parameters.ToDictionary<KeyValuePair<string, string>, string, object>(parameter => parameter.Key, parameter => parameter.Value);

            if (!parametersDictionary.Keys.Contains("CssClass")) return result;

            parametersDictionary.TryGetValue("CssClass", out var guid);

            if (guid == null) return result;

            var objItem = Context.Database.Items.GetItem(new ID(guid.ToString()));

            result.Add("CssClass", objItem["Class"]);

            return result;
        }
    }
}