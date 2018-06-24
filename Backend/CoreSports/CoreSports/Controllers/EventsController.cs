using System.Collections.Generic;
using System.Linq;
using CoreSports.Services.Contracts;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CoreSports.Controllers
{
    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMappingService mappingService;

        public EventsController(IUnitOfWork unitOfWork, IMappingService mappingService)
        {
            this.unitOfWork = unitOfWork;
            this.mappingService = mappingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok(this.unitOfWork.Events.Entities.ToList());
        }

        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            using (var input = file.OpenReadStream())
            {
                var mappedEvents = this.mappingService.MapToEvents(input);
            }

            return this.Ok();
        }
    }
}