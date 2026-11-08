using lab3.Data;
using lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers
{
    public class WorkshopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkshopsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public static readonly string[] WorkshopTitles =
        {
            "Routing Basics",
            "EF Core Intro",
            "Razor Essentials"
        };

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RsvpForm()
        {
            ViewBag.Workshops = WorkshopTitles;
            return View(new Rsvp());
        }

        [HttpPost]
        public IActionResult Confirm(Rsvp model)
        {
            ViewData["Message"] = $"Thanks for registering, {model.FullName}!";
            return View(model);
        }

        public IActionResult Registrations()
        {
            var registrations = _context.Rsvps.ToList();
            return View(registrations);
        }
    }
}