using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Hackathon.Foundation.Send.Models;
using Microsoft.Extensions.Logging;

namespace Hackathon.Foundation.Send.Services
{
    public class TrackHttpService : ITrackHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<TrackHttpService> _logger;

        public TrackHttpService(IHttpClientFactory httpClientFactory, ILogger<TrackHttpService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<TrackResult> SendEvent(Event @event)
        {
            var client = _httpClientFactory.CreateClient(Constants.ClientName);
            var url = @event.ActionType == ActionType.IDENTIFY ? "/identify" : "/track";
            _logger.Log(LogLevel.Information, "Send ActionType: {ActionType}", @event.ActionType);
            await client.PostAsync(url, JsonContent.Create(@event));
            return new TrackResult()
            {
                ActionType = @event.ActionType,
                Status = TrackStatus.SENT,
            };
        }
    }
}
