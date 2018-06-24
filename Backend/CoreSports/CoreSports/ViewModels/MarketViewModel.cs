using System.Collections.Generic;

namespace CoreSports.ViewModels
{
    public class MarketViewModel
    {
        public MarketViewModel()
        {
            this.Selections = new List<SelectionViewModel>();
        }

        public int Id { get; set; }

        public int InternalId { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public int EventId { get; set; }

        public IList<SelectionViewModel> Selections { get; set; }
    }
}
