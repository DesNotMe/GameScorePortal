using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace GameScorePortal.Data
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        [StringLength(20)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]

        [StringLength(20)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]

        [DisplayName("Joined Date")]
        public DateTime JoinDate { get; set; }
        public ICollection<GameScore> GameScores { get; set; }

    }
}
