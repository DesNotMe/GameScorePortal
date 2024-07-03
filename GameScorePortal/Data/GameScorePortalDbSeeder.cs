using GameScorePortal.Data;

namespace GameScorePortal.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GameScorePortalDbContext context)
        {
            // Look for any students.
            if (context.Players.Any())
            {
                return;   // DB has been seeded
            }

            var players = new Player[]
            {
                new Player{FirstName="Carson",LastName="Alexander",JoinDate = new DateTime(2023, 1, 1, 10, 0, 0),},
                new Player{FirstName = "Meredith", LastName = "Alonso", JoinDate = new DateTime(2023, 10, 1, 10, 5, 0)},
                new Player{FirstName="Arturo",LastName="Anand",JoinDate = new DateTime(2023, 1, 1, 10, 3, 0)}
            };

            context.Players.AddRange(players);
            context.SaveChanges();

            var games = new Game[]
            {
                new Game{Name="PUBG",Genre="Action"},
                new Game{Name="FIFA",Genre="Sports"},
                new Game{Name="DOTA",Genre="Strategy"},
                };

            context.Games.AddRange(games);
            context.SaveChanges();

            var gamescores = new GameScore[]
            {
                new GameScore{PlayerID=1,GameID=1,Score=12.3},
                new GameScore{PlayerID = 3,GameID=2,Score=13.5},
                new GameScore{PlayerID=2,GameID=3,Score=18.4},
            };

            context.GameScores.AddRange(gamescores);
            context.SaveChanges();
        }
    }
}