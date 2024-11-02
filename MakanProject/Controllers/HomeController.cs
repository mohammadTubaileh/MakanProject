using MakanProject.Data;
using MakanProject.Models;
using MakanProject.Models.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;

namespace MakanProject.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		AppDbContext db;
		public HomeController(ILogger<HomeController> logger, AppDbContext _db)
		{
			_logger = logger;
			db = _db;

        }

		public IActionResult Index()
		{
            IndexDataModel model = new IndexDataModel
            {

                Villas = db.Villas.ToList(),
                Apartments = db.Apartments.ToList(),
                 Locations = db.Locations.ToList(), 
				 	Requests = db.Requests.ToList(),	
        


        };
            return View(model);

            
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
