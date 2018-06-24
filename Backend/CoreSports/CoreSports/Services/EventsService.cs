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
            foreach (var model in models)
            {
                var databaseEvent =
                    this.unitOfWork.Events.Entities.FirstOrDefault(x => x.InternalId == model.InternalId);

                this.UpdateEvents(databaseEvent, model);
            }

            this.unitOfWork.Commit();
        }

        private void UpdateEvents(Event databaseEvent, Event updateEvent)
        {
            if (databaseEvent != null)
            {
                databaseEvent.Away = updateEvent.Away;
                databaseEvent.Home = updateEvent.Home;
                databaseEvent.Time = updateEvent.Time;
                databaseEvent.Type = updateEvent.Type;

                foreach (var market in updateEvent.Markets)
                {
                    var databaseMarket =
                        this.unitOfWork.Markets.Entities.FirstOrDefault(x => x.InternalId == market.InternalId);

                    this.UpdateMarket(databaseMarket, market);
                }
            }
        }

        private void UpdateMarket(Market databaseMarket, Market updateMarket)
        {
            if (databaseMarket != null)
            {
                databaseMarket.Name = updateMarket.Name;
                databaseMarket.Number = updateMarket.Number;
                databaseMarket.Status = updateMarket.Status;
            }

            foreach (var selection in updateMarket.Selections)
            {
                var databaseSelection =
                    this.unitOfWork.Selections.Entities.FirstOrDefault(x => x.InternalId == selection.InternalId);
                UpdateSelection(databaseSelection, selection);
            }
        }

        private static void UpdateSelection(Selection databaseSelection, Selection updateSelection)
        {
            if (databaseSelection != null)
            {
                databaseSelection.Description = updateSelection.Description;
                databaseSelection.Number = updateSelection.Number;
                databaseSelection.Odds = updateSelection.Odds;
                databaseSelection.ParticipantType = updateSelection.ParticipantType;
            }
        }

        public IEnumerable<EventViewModel> MapToViewModels(IEnumerable<Event> models)
        {
            return models.Select((x) => new EventViewModel
            {
                Id = x.Id,
                InternalId = x.InternalId,
                Away = x.Away,
                Home = x.Home,
                Time = x.Time,
                Type = x.Type,
                Markets = x.Markets.Select(y => new MarketViewModel
                {
                    Id = y.Id,
                    InternalId = y.InternalId,
                    Name = y.Name,
                    EventId = y.EventId,
                    Number = y.Number,
                    Status = y.Status,
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
