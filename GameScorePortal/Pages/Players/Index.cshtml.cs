using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameScorePortal.Data;
using GameScorePortal.Helper;

namespace GameScorePortal.Pages.Players
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
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Player> Players { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;

            IQueryable<Player> playersIQ = from p in _context.Players
                                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                playersIQ = playersIQ.Where(s => s.LastName.Equals(searchString, StringComparison.OrdinalIgnoreCase) ||
                                                 s.FirstName.Equals(searchString, StringComparison.OrdinalIgnoreCase));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    playersIQ = playersIQ.OrderByDescending(p => p.LastName);
                    break;
                case "Date":
                    playersIQ = playersIQ.OrderBy(p => p.JoinDate);
                    break;
                case "date_desc":
                    playersIQ = playersIQ.OrderByDescending(p => p.JoinDate);
                    break;
                default:
                    playersIQ = playersIQ.OrderBy(p => p.LastName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Players = await PaginatedList<Player>.CreateAsync(playersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
