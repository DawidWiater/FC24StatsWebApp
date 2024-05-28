using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FC24StatsWebApp.Data;
using FC24StatsWebApp.Models;

namespace FC24StatsWebApp.Controllers
{
    public class ResultsController : Controller
    {
        private readonly AppDbContext _context;

        public ResultsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Results
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Results.Include(r => r.Player).Include(r => r.Tournament);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Results/Create
        public IActionResult Create()
        {
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "Name");
            ViewData["TournamentID"] = new SelectList(_context.Tournaments, "TournamentID", "Name");
            return View();
        }

        // POST: Results/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResultID,PlayerID,TournamentID,Place,Points")] Result result)
        {
            if (ModelState.IsValid)
            {
                _context.Add(result);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "Name", result.PlayerID);
            ViewData["TournamentID"] = new SelectList(_context.Tournaments, "TournamentID", "Name", result.TournamentID);
            return View(result);
        }

        // other actions ...
    }
}
