using System.Collections.Generic;
using System.Linq;
using CoreSports.Services.Contracts;
using CoreSports.Services.Models;
using CoreSports.ViewModels;
using Data.UnitOfWork;
using Models;

namespace CoreSports.Services
{
    public class EventsService : IEventsService
    {
        private readonly IUnitOfWork unitOfWork;

        public EventsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Import(EventCommand command)
        {
            if (command.Type == CommandType.Create)
            {
                this.AddModels(command.Models);
            }
            else
            {
                this.UpdateModels(command.Models);
            }
        }

        private void AddModels(IList<Event> models)
        {
            foreach (var model in models)
            {
                this.unitOfWork.Events.Add(model);
            }

            this.unitOfWork.Commit();
        }

        private void UpdateModels(IList<Event> models)
        {
        }

        public IEnumerable<EventViewModel> MapToViewModels(IEnumerable<Event> models)
        {
            return models.Select((x) => new EventViewModel
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
        }
    }
}
