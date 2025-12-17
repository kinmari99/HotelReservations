using Hotel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class RejestracjaController : Controller
    {
        private static HotelsDBContext _context;
        public RejestracjaController(HotelsDBContext context) { _context = context; }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Rejestracja(Użytkownik rejestracja)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(rejestracja);
                _context.SaveChanges();
                return View("Wynik", rejestracja);
            }
            else { return View("Index", rejestracja); }
        }
        [HttpPost]
        public IActionResult Wynik(Użytkownik rejestracja)
        {
            return View(rejestracja);
        }
    }
}
