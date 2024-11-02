using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakanProject.Data;
using MakanProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace MakanProject.Controllers
{
    public class VillasController : Controller
    {
        private readonly AppDbContext _context;
        

        public VillasController(AppDbContext context)
        {
            _context = context;
            
        }

        // GET: Villas
        public async Task<IActionResult> Index()
        {

            return View(await _context.Villas.ToListAsync());
        }

        // GET: Villas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var villa = await _context.Villas
                .FirstOrDefaultAsync(m => m.VillaId == id);
            if (villa == null)
            {
                return NotFound();
            }

            return View(villa);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(Villa villa, IFormFile imageUpload)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null && imageUpload.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageUpload.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageUpload.CopyToAsync(fileStream);
                    }

                    villa.VillaImageUrl = $"/img/{uniqueFileName}";
                }

                _context.Villas.Add(villa);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(villa);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var villa = await _context.Villas.FindAsync(id);
            if (villa == null)
            {
                return NotFound();
            }
            return View(villa);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Villa villa)
        {
            if (id != villa.VillaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(villa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VillaExists(villa.VillaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(villa);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var villa = await _context.Villas
                .FirstOrDefaultAsync(m => m.VillaId == id);
            if (villa == null)
            {
                return NotFound();
            }

            return View(villa);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var villa = await _context.Villas.FindAsync(id);
            if (villa != null)
            {
                _context.Villas.Remove(villa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VillaExists(int id)
        {
            return _context.Villas.Any(e => e.VillaId == id);
        }
       



    }
}
