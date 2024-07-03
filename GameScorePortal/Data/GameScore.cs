using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameScorePortal.Data
{
    public class GameScore
    {
        [Key]
        public int GameScoresId { get; set; }
        public int GameID { get; set; }
        [ForeignKey("GameID")]

        public int PlayerID { get; set; }
        [ForeignKey("PlayerID")]
        public double Score { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }

    }
}
