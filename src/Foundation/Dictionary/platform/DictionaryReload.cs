using System.Linq;
using System.Net.Http;
using Sitecore.Diagnostics;
using Sitecore.Publishing.Pipelines.Publish;

namespace Hackathon.Foundation.Dictionary
{
    public class DictionaryReload : PublishProcessor
    {
        public override void Process(PublishContext context)
        {
            Assert.ArgumentNotNull(context, "context");

            if (context.Aborted)
                return;

            var processedItems = context.ProcessedPublishingCandidates.Keys
                .Select(item => context.PublishOptions.TargetDatabase.GetItem(item.ItemId))
                .Where(item => item != null);

            if (processedItems.All(item => item.TemplateID != Templates.DictionaryEntry))
            {
                return;
            }

            var url = "http://rendering/api/localization/reload";
            var data = new StringContent("");
            var client = new HttpClient();

            client.PostAsync(url, data);
        }
    }
}