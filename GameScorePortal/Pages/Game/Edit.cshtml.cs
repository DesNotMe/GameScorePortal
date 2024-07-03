using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameScorePortal.Data;

namespace GameScorePortal.Pages.Game
{
    public class EditModel : PageModel
    {
        private readonly GameScorePortal.Data.GameScorePortalDbContext _context;

        public EditModel(GameScorePortal.Data.GameScorePortalDbContext context)
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
            Game = game;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(Game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(Game.GameId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlayerExists(int id)
        {
            return _context.Games.Any(e => e.GameId == id);
        }
    }
}
