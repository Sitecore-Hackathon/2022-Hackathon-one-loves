using Hackathon.Foundation.Send.Models;
using System.Threading.Tasks;

namespace Hackathon.Foundation.Send.Services
{
    public interface ITrackHttpService
    {
        Task<TrackResult> SendEvent(Event @event);
    }
}
