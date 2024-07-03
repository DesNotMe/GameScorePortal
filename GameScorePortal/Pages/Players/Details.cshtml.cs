using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameScorePortal.Data;

namespace GameScorePortal.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly GameScorePortal.Data.GameScorePortalDbContext _context;

        public DetailsModel(GameScorePortal.Data.GameScorePortalDbContext context)
        {
            _context = context;
        }

        public Player Player { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players.FirstOrDefaultAsync(m => m.PlayerId == id);
            if (player == null)
            {
                return NotFound();
            }
            else
            {
                Player = player;
            }
            return Page();
        }
    }
}
