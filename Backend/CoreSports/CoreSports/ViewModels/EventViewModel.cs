using System;
using System.Collections.Generic;
using Models;

namespace CoreSports.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel()
        {
            this.Markets = new List<MarketViewModel>();
        }

        public int Id { get; set; }

        public int InternalId { get; set; }

        public DateTime Time { get; set; }

        public string Name { get; set; }

        public EventType Type { get; set; }

        public string Home { get; set; }

        public string Away { get; set; }

        public IList<MarketViewModel> Markets { get; set; }
    }
}
