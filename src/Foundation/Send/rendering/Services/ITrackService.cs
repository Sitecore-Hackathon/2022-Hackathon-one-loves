using Hackathon.Foundation.Send.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Foundation.Send.Services
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackResult>> Track(IEnumerable<Event> events);
        Task<TrackResult> Track(Event @event);
    }
}
