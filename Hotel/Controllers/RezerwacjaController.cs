using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System;

namespace Hotel.Controllers
{
    
    public class RezerwacjaController : Controller
    {
        private static HotelsDBContext _context;
        public RezerwacjaController(HotelsDBContext context) { _context = context; }
        // Strona główna (lista rezerwacji)
        public IActionResult Index()
        {
            // Pobiera listę rezerwacji z bazy danych
            var reservations = _context.Reservations.Include(r => r.użytkownik).ToList();
            return View(reservations);
        }

        // GET: Formularz do tworzenia nowej rezerwacji
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
              Użytkownik match = _context.Users.FirstOrDefault(user => user.Email == rezerwacja.Email); 
                rezerwacja.użytkownik = match;
                _context.Reservations.Add(rezerwacja);
                _context.SaveChanges();
                RedirectToAction("Index");
                
            }
             return View("Wynik",rezerwacja); 
        }

        // GET: Szczegóły rezerwacji
        public IActionResult Details(int id)
        {
            var rezerwacja = _context.Reservations
                .Include(r => r.użytkownik)
                .FirstOrDefault(r => r.Id == id);

            if (rezerwacja == null)
            {
                return NotFound();
            }
            if (User.IsInRole("Admin") || rezerwacja.Email == User.Identity.Name)

            {
                
                return View(rezerwacja);
            }
            
            return Forbid(); 


          
        }

        // GET: Formularz do edycji rezerwacji
        public IActionResult Edit(int id)
        {
            var rezerwacja = _context.Reservations.Find(id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            
            
            if (User.IsInRole("Admin") || rezerwacja.Email == User.Identity.Name)
            {
                
                return View(rezerwacja);
            }

            return Forbid(); 

            
        }
        // POST: Aktualizacja rezerwacji
        [HttpPost]
        public IActionResult Edit(int id, Rezerwacja updatedRezerwacja)
        {
            if (id != updatedRezerwacja.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Entry(updatedRezerwacja).State = EntityState.Modified;
                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Reservations.Any(r => r.Id == id))
                    {
                        return NotFound();
                    }
                    throw;
                }

                return RedirectToAction("Index");
            }

            return View(updatedRezerwacja);
        }

        // GET: Formularz do usuwania rezerwacji
        public IActionResult Delete(int id)
        {
            var rezerwacja = _context.Reservations.Find(id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Admin") || rezerwacja.Email == User.Identity.Name)

            {
                
                return View(rezerwacja);
            }

            return Forbid(); 

          
        }

        // POST: Usunięcie rezerwacji
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var rezerwacja = _context.Reservations.Find(id);
            if (rezerwacja != null)
            {
                _context.Reservations.Remove(rezerwacja);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        
    }
}
