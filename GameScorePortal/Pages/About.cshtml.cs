using GameScorePortal.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GameScorePortal.Pages
{
    public class AboutModel : PageModel
    {
        private readonly GameScorePortalDbContext _context;

        public AboutModel(GameScorePortalDbContext context)
        {
            _context = context;
        }

        public List<PlayerJoinCount> PlayerJoinCounts { get; set; } = new();

        public async Task OnGetAsync()
        {
            PlayerJoinCounts = await _context.Players
                .GroupBy(p => p.JoinDate.Date) // Group by date part only
                .Select(group => new PlayerJoinCount
                {
                    Date = group.Key,
                    Count = group.Count()
                })
                .OrderBy(x => x.Date) // Sort by date for presentation
                .ToListAsync();
        }
    }

    public class PlayerJoinCount
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
