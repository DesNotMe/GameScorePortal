using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameScorePortal.Data;

namespace GameScorePortal.Pages.Players
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
        public Player Player { get; set; }

        // To protect from overposting attacks, see 
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values.SelectMany(v => v.Errors);
            //    foreach (var error in errors)
            //    {
            //        Console.WriteLine(error.ErrorMessage); // Log or handle errors as needed
            //    }
            //    return Page();
            //}

            //try
            //{
            //    _context.Players.Add(Player);
            //    await _context.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}"); // Log error
            //                                                           // Optionally add a model error to notify the user
            //    ModelState.AddModelError(string.Empty, "An error occurred while saving the player.");
            //    return Page();
            //}

            //return RedirectToPage("./Index");
            _context.Players.Add(Player);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }

    }
}
