using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UserBet
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int SelectionId { get; set; }

        public virtual Selection Selection { get; set; }
    }
}
