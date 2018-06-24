using System.Collections.Generic;
using CoreSports.Services.Models;
using CoreSports.ViewModels;
using Models;

namespace CoreSports.Services.Contracts
{
    public interface IEventsService
    {
        void Import(EventCommand command);

        IEnumerable<EventViewModel> MapToViewModels(IEnumerable<Event> models);
    }
}
