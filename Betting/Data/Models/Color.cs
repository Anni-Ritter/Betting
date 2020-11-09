using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Betting.Data.Models
{
    public class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new HashSet<Team>();
            this.SecondaryKitTeams = new HashSet<Team>();
        }

        [Key]
        public int CountryId { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        public virtual ICollection<Team> PrimaryKitTeams { get; set; }
        public virtual ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
