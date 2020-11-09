using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Betting.Data.Models
{
    public class PlayerStatistic
    {
        public string Assists { get; set; }
        public int MinutesPlayed { get; set; }
        public int ScoredGoals { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
