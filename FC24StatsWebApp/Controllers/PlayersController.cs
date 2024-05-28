using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FC24StatsWebApp.Data;
using FC24StatsWebApp.Models;

namespace FC24StatsWebApp.Controllers
{
    public class PlayersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PlayersController> _logger;

        public PlayersController(AppDbContext context, ILogger<PlayersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            return View(await _context.Players.ToListAsync());
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerID,Name,Username")] Player player)
        {
            _logger.LogInformation("Create action invoked");
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Player created successfully");
                return RedirectToAction(nameof(Index));
            }
            _logger.LogWarning("Model state is invalid");
            return View(player);
        }

        // other actions ...
    }
}
