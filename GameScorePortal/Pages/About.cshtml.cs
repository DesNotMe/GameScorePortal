using GameScorePortal.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameScorePortal.Pages
{
    public class AboutModel : PageModel
{
    private readonly GameScorePortalDbContext _context;

    public AboutModel(GameScorePortalDbContext context)
    {
        _context = context;
    }

    public IEnumerable<JoinDateCount> PlayerJoinStats { get; set; }

    public void OnGet()
    {
        var players = _context.Players.ToList();
        PlayerJoinStats = players.GroupBy(player => player.JoinDate.Date)
                                 .Select(group => new JoinDateCount { JoinDate = group.Key, Count = group.Count() });
    }
}

    public class JoinDateCount // This could be a separate model class
    {
        public DateTime JoinDate { get; set; }
        public int Count { get; set; }
    }
}
