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
    public class DeleteModel : PageModel
    {
        private readonly GameScorePortal.Data.GameScorePortalDbContext _context;

        public DeleteModel(GameScorePortal.Data.GameScorePortalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GameScorePortal.Data.Game Game { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FirstOrDefaultAsync(m => m.GameId == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                Game = game;
                _context.Games.Remove(Game);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
