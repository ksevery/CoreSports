using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Market
    {
        private ICollection<Selection> selections;

        public Market()
        {
            this.selections = new HashSet<Selection>();
        }

        [Key]
        public int Id { get; set; }

        public int InternalId { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }

        public MarketStatus Status { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        public virtual ICollection<Selection> Selections
        {
            get => this.selections;
            set => this.selections = value;
        }
    }
}
