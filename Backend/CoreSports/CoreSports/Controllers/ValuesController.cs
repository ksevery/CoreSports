using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreSports.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IUnitOfWork _data;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            _data = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
