using Microsoft.EntityFrameworkCore;

namespace GameScorePortal.Data
{
    public class GameScorePortalDbContext:DbContext
    {
        public GameScorePortalDbContext(DbContextOptions<GameScorePortalDbContext> options): base (options) { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameScore> GameScores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<GameScore>().ToTable("GameScore");

        }

    }
}
