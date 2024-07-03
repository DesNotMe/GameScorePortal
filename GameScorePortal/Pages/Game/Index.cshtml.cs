using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameScorePortal.Data;
using GameScorePortal.Helper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GameScorePortal.Pages.Game
{
    public class IndexModel : PageModel
    {
        private readonly GameScorePortalDbContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(GameScorePortalDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string GenreSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<GameScorePortal.Data.Game> Games { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            GenreSort = sortOrder == "Genre" ? "genre_desc" : "Genre";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            IQueryable<GameScorePortal.Data.Game> gamesIQ = from g in _context.Games
                                       select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                string upperSearchString = searchString.ToUpper();
                gamesIQ = gamesIQ.Where(s => s.Name.ToUpper().Contains(upperSearchString) || s.Genre.ToUpper().Contains(upperSearchString) || (s.Name + " " + s.Genre).ToUpper().Contains(upperSearchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    gamesIQ = gamesIQ.OrderByDescending(s => s.Name);
                    break;
                case "Genre":
                    gamesIQ = gamesIQ.OrderBy(s => s.Genre);
                    break;
                case "genre_desc":
                    gamesIQ = gamesIQ.OrderByDescending(s => s.Genre);
                    break;
                default:
                    gamesIQ = gamesIQ.OrderBy(s => s.Name);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Games = await PaginatedList<GameScorePortal.Data.Game>.CreateAsync(
                gamesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
