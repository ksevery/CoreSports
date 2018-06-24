using System.Collections.Generic;
using System.Linq;
using CoreSports.Services.Contracts;
using CoreSports.ViewModels;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace CoreSports.Controllers
{
    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMappingService mappingService;
        private readonly IEventsService eventsService;

        public EventsController(IUnitOfWork unitOfWork, IMappingService mappingService, IEventsService eventsService)
        {
            this.unitOfWork = unitOfWork;
            this.mappingService = mappingService;
            this.eventsService = eventsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = this.eventsService.MapToViewModels(this.unitOfWork.Events.Entities.Include(x => x.Markets).Include("Markets.Selections"));
            return this.Ok(result);
        }

        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            using (var input = file.OpenReadStream())
            {
                var improtCommand = this.mappingService.MapToEvents(input);
                this.eventsService.Import(improtCommand);
            }

            return this.Ok();
        }
    }
}