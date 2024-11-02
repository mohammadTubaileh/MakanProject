using MakanProject.Data;
using MakanProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MakanProject.Controllers
{
    public class BookingsController : Controller
    {
      
    private readonly AppDbContext _db;

        public BookingsController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index() 
        {
            return View();
        }

        public IActionResult Create(int villaId)
        {
            
            var villa = _db.Villas.FirstOrDefault(v => v.VillaId == villaId);
            if (villa == null )
            {
                return NotFound("Villa not available.");
            }

            var model = new Booking
            {
                
                VillaId = villaId,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            bool isAvailable = !_db.Bookings
       .Any(r => r.VillaId == booking.VillaId &&
                 r.StartDate < booking.EndDate &&
                 booking.StartDate < r.EndDate);

            if (!isAvailable)
            {
                ModelState.AddModelError("", "The villa is not available for the selected dates.");
                return View(booking);
            }
            else
            {
                _db.Bookings.Add(booking);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
        
    }
}
