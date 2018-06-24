using System.Collections.Generic;
using Models;

namespace CoreSports.ViewModels
{
    public class SelectionViewModel
    {
        public int Id { get; set; }

        public int InternalId { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }

        public decimal Odds { get; set; }

        public ParticipantType ParticipantType { get; set; }

        public int MarketId { get; set; }
    }
}
