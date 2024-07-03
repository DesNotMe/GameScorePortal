using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameScorePortal.Data;

namespace GameScorePortal.Pages.Game
{
    public class CreateModel : PageModel
    {
        private readonly GameScorePortal.Data.GameScorePortalDbContext _context;

        public CreateModel(GameScorePortal.Data.GameScorePortalDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GameScorePortal.Data.Game Game { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Games.Add(Game);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
