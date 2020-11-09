using Betting.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace Betting.Data
{
    public class BettingContext: DbContext
    {
        public BettingContext()
        {
        }

        public BettingContext(DbContextOptions options)
            :base(options)
        {
        }

        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Town> Towns { get; set; } 
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=Betting;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(sc => new { sc.GameId, sc.PlayerId });
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.GameId);
            
                entity.HasOne(g => g.HomeTeam)
                      .WithMany(h => h.HomeGames)
                      .HasForeignKey(g => g.HomeTeamId)
                      .OnDelete(DeleteBehavior.Restrict);
            
                entity.HasOne(g => g.AwayTeam)
                      .WithMany(a => a.AwayGames)
                      .HasForeignKey(g => g.AwayTeamId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.TeamId);

                entity.HasOne(p => p.PrimaryKitColor)
                      .WithMany(t => t.PrimaryKitTeams)
                      .HasForeignKey(p => p.PrimaryKitColorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.SecondaryKitColor)
                      .WithMany(t => t.SecondaryKitTeams)
                      .HasForeignKey(s => s.SecondaryKitColorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
