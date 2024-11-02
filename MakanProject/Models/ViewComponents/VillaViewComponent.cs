using MakanProject.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
namespace MakanProject.Models.ViewComponents
    
{
    public class VillaViewComponent : ViewComponent
    {
        public AppDbContext db;
        public VillaViewComponent(AppDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()
        {
            return View(db.Villas);
        }
    }
}
