using MakanProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace MakanProject.Models.ViewComponents
{
    public class ApartmentViewComponent : ViewComponent
    {
        public AppDbContext db;
        public ApartmentViewComponent(AppDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.Apartments);
        }
    }
}
