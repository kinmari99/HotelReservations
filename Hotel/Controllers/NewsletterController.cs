using Hotel.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class NewsletterController : Controller
    {
        private static HotelsDBContext _context;
        public NewsletterController(HotelsDBContext context) {  _context = context; }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Newsletter(Newsletter newsletter)
        {
            if (ModelState.IsValid)
            {
                Użytkownik match = _context.Users.FirstOrDefault(user => user.Email == newsletter.Email);
                newsletter.użytkownik = match;
                _context.Newsletters.Add(newsletter);
                _context.SaveChanges();
                return View("Wynik", newsletter);
            }
            else { return View("Index", newsletter); }
        }
        [HttpPost]
        public IActionResult Wynik(Newsletter newsletter)
        {
            return View(newsletter);
        }
    }
}
