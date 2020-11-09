using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Betting.Data.Models
{
    public class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }

        [Key]
        public int UserId { get; set; }

        public decimal Balance { get; set; }

        [MaxLength(64)]
        public string Email { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }
        public string Password { get; set; }

        [MaxLength(128)]
        public string UserName { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
