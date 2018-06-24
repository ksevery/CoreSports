using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Selection
    {
        private ICollection<UserBet> userBets;

        public Selection()
        {
            this.userBets = new HashSet<UserBet>();
        }

        [Key]
        public int Id { get; set; }

        public int InternalId { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }

        public decimal Odds { get; set; }

        public ParticipantType ParticipantType { get; set; }

        public int MarketId { get; set; }

        public virtual Market Market { get; set; }

        public virtual ICollection<UserBet> UserBets
        {
            get => this.userBets;
            set => this.userBets = value;
        }
    }
}
