using MakanProject.Data;
using MakanProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MakanProject.Controllers
{
    public class RequestController : Controller
    {
        private readonly AppDbContext _context;


        public RequestController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            var request = await _context.Requests.ToListAsync();
            return View(request);
        }
        public IActionResult SendRequest()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendRequest(Request request)
        {
            

            if (ModelState.IsValid)
            {

                _context.Requests.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(request);
            
        }

        public async Task<IActionResult> ShowRequest(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request != null)
            {
                _context.Requests.Remove(request);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Show()
        { 
            return View();
        }


    }
}
