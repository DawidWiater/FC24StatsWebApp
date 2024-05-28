using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FC24StatsWebApp.Data;
using FC24StatsWebApp.Models;
using System.Diagnostics;

namespace FC24StatsWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult AllTimeTable()
        {
            var players = _context.Players
                .Include(p => p.Results)
                .Select(p => new PlayerViewModel
                {
                    PlayerID = p.PlayerID,
                    Name = p.Name,
                    Username = p.Username,
                    TotalPoints = p.Results.Sum(r => r.Points),  // Sumowanie punktów
                    FirstPlaceCount = p.Results.Count(r => r.Place == 1),
                    SecondPlaceCount = p.Results.Count(r => r.Place == 2),
                    ThirdPlaceCount = p.Results.Count(r => r.Place == 3),
                    OtherPlaceCount = p.Results.Count(r => r.Place > 3)
                })
                .OrderByDescending(p => p.TotalPoints)          // Sortowanie po punktach
                .ThenBy(p => p.FirstPlaceCount)                 // Sortowanie po liczbie pierwszych miejsc
                .ToList();

            return View(players);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
