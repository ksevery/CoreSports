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

        public EventsController(IUnitOfWork unitOfWork, IMappingService mappingService)
        {
            this.unitOfWork = unitOfWork;
            this.mappingService = mappingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = this.unitOfWork.Events.Entities.Include(x => x.Markets).Include("Markets.Selections").Select((x) => new EventViewModel
            {
                Id = x.Id,
                InternalId = x.InternalId,
                Away = x.Away,
                Home = x.Home,
                Name = x.Name,
                Time = x.Time,
                Type = x.Type,
                Markets = x.Markets.Select(y => new MarketViewModel
                {
                    Id = y.Id,
                    InternalId = y.InternalId,
                    Name = y.Name,
                    EventId = y.EventId,
                    Number = y.Number,
                    Selections = y.Selections.Select(z => new SelectionViewModel
                    {
                        Id = z.Id,
                        InternalId = z.InternalId,
                        ParticipantType = z.ParticipantType,
                        Number = z.Number,
                        Description = z.Description,
                        MarketId = z.MarketId,
                        Odds = z.Odds
                    }).ToList()
                }).ToList()
            });
            return this.Ok(result);
        }

        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            using (var input = file.OpenReadStream())
            {
                var mappedEvents = this.mappingService.MapToEvents(input);

                foreach (var mappedEvent in mappedEvents)
                {
                    this.unitOfWork.Events.Add(mappedEvent);
                }

                this.unitOfWork.Commit();
            }

            return this.Ok();
        }
    }
}