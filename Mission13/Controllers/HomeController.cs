using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }

        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(string teamName)
        {

            // list of bowlers with team
            var x = _repo.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team.TeamName == teamName || teamName == null)
                .OrderBy(b => b.Team.TeamName)
                .ToList();

            return View(x);
        }



        [HttpGet]
        public IActionResult AddBowler()
        {
            ViewBag.Teams = _repo.Teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {

            if (ModelState.IsValid)
            {
                b.BowlerID = (_repo.Bowlers.Max(b => b.BowlerID)) + 1;
                _repo.CreateBowler(b);
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Teams = _repo.Teams.ToList();
                return View(b);
            }

        }

        // Edit / delete
        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {

            ViewBag.Teams = _repo.Teams.ToList();
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == bowlerid);
            return View("AddBowler", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler update)
        {
            _repo.SaveBowler(update);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Bowler delete)
        {
            _repo.DeleteBowler(delete);

            return RedirectToAction("Index");
        }
    }
}
