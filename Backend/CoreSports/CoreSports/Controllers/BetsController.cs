using Microsoft.AspNetCore.Mvc;

namespace CoreSports.Controllers
{
    [Produces("application/json")]
    [Route("api/Bets")]
    public class BetsController : Controller
    {
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}