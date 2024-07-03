using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace GameScorePortal.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        
        public ICollection<GameScore> GameScores { get; set; }
    }
}
