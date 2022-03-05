using Hackathon.Foundation.Send.Models;
using Hackathon.Foundation.Send.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.Foundation.Send.Controllers
{
    [Route("[controller]")]
    public class TrackController : ControllerBase
    {
        private readonly ITrackService _trackService;

        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpPost]
        public async Task<IEnumerable<TrackResult>> Events([FromBody] IList<Event> events)
        {
            return await _trackService.Track(events);
        }

        [HttpPost]
        public async Task<TrackResult> Event([FromBody]Event events)
        {
            return await _trackService.Track(events);
        }
    }
}
