using MakanProject.Data;
using MakanProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MakanProject.Controllers
{
    public class LocateController : Controller
    {
        private readonly AppDbContext _db;
        public LocateController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var locations = _db.Locations.ToList();
            return View(locations);
        }

        public IActionResult SaveLocation()
        {
            return View();
        }

        

        [HttpPost]
        public IActionResult SaveLocation(double latitude, double longitude)
        {
            var location = new Location
            {
                Latitude = latitude,
                Longitude = longitude,
               
            };

            _db.Locations.Add(location);
            _db.SaveChanges();

            return Json(new { success = true });
        }

        public IActionResult ShowLocation()
        {
            var location = _db.Locations.FirstOrDefault();
            if (location == null)
            {
                
                return NotFound("No location found.");
            }
            
            return View(location);
        }
    }
}
