using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Event
    {
        private ICollection<Market> markets;

        public Event()
        {
            this.markets = new HashSet<Market>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public string Name { get; set; }

        public EventType Type { get; set; }

        public string Home { get; set; }

        public string Away { get; set; }

        public virtual ICollection<Market> Markets
        {
            get => this.markets;
            set => this.markets = value;
        }
    }
}
