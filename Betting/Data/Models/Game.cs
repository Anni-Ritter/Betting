using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Betting.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.Bets = new HashSet<Bet>();
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }


        [Key]
        public int GameId { get; set; }

        public string AwayTeamBetRate { get; set; }
        public string AwayTeamGoals { get; set; }
        public string DrawBetRate { get; set; }
        public string HomeTeamBetRate { get; set; }
        public string HomeTeamGoals { get; set; }
        public string Result { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("AwayTeam")]
        public int AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }
        [ForeignKey("HomeTeam")]
        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
