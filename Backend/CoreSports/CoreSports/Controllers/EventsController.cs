using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CoreSports.Controllers
{
    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new [] { "value1", "value2" };
        }
    }
}