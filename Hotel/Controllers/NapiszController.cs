using Hotel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class NapiszController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Napisz(Napisz napisz)
        {
            if (ModelState.IsValid)
            {
                return View("Wynik", napisz);
            }
            else { return View("Index", napisz); }
        }
        [HttpPost]
        public IActionResult Wynik(Napisz napisz)
        {
            return View(napisz);
        }
    }
}
