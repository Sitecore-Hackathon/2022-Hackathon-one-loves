using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Foundation.Send.Extensions;
using Hackathon.Foundation.Send.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Hackathon.Foundation.Send.Services
{
    public class TrackService : ITrackService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ITrackHttpService _trackHttpService;

        public TrackService(IServiceScopeFactory serviceScopeFactory, ITrackHttpService trackHttpService)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _trackHttpService = trackHttpService;
        }

        public async Task<IEnumerable<TrackResult>> Track(IEnumerable<Event> input)
        {
            var events = input.OrderBy(x => x.ActionType).ToArray();
            if (events.Length == 0)
            {
                return Enumerable.Empty<TrackResult>();
            }

            var first = events[0];
            if (first.ActionType == ActionType.IDENTIFY)
            {
                var rest = events[1..];
                var result = new List<TrackResult>();
                result.Add(await _trackHttpService.SendEvent(first));
                result.AddRange(SendWithDelay(rest));
                return result;
            }

            return await events.Select(x => _trackHttpService.SendEvent(x));
        }

        public Task<TrackResult> Track(Event @event)
        {
            return _trackHttpService.SendEvent(@event);
        }

        private IEnumerable<TrackResult> SendWithDelay(IEnumerable<Event> events)
        {
            _ = Task.Run(async () =>
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var trackHttpService = scope.ServiceProvider.GetService<ITrackHttpService>();
                foreach (var @event in events)
                {
                    await Task.Delay(2000);
                    if (trackHttpService != null) await trackHttpService.SendEvent(@event);
                }
            }
            );
            return events.Select(x => new TrackResult()
            {
                ActionType = x.ActionType,
                Status = TrackStatus.LATER,
            });
        }
    }
}
