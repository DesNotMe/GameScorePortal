using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameScorePortal.Data;

namespace GameScorePortal.Pages.Game
{
    public class DetailsModel : PageModel
    {
        private readonly GameScorePortal.Data.GameScorePortalDbContext _context;

        public DetailsModel(GameScorePortal.Data.GameScorePortalDbContext context)
        {
            _context = context;
        }

        public GameScorePortal.Data.Game Game { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games
                .Include(s => s.GameScores)
                .ThenInclude(e => e.Player)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.GameId == id);

            if (game == null)
            {
                return NotFound();
            }
            else
            {
                Game = game;
            }
            return Page();
        }
    }
}
