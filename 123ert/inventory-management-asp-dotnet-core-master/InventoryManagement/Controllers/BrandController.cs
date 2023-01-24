using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagement.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin,StoreAdmin")]
    public class BrandController : Controller
    {
        public long UserId { get { return Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier)); } }
        private readonly yournotebookContext _context;

        public BrandController(yournotebookContext context)
        {
            _context = context;
        }

        // GET: Brand
        public async Task<IActionResult> Index()
        {
            return View(await _context.BrandMaster.ToListAsync());
        }

        // GET: Brand/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandMaster = await _context.BrandMaster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brandMaster == null)
            {
                return NotFound();
            }

            return View(brandMaster);
        }

        // GET: Brand/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandMaster brandMaster)
        {
            if (ModelState.IsValid)
            {
                brandMaster.CreatedBy = UserId;
                brandMaster.CreatedDate = DateTime.Now;
                _context.Add(brandMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brandMaster);
        }

        // GET: Brand/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandMaster = await _context.BrandMaster.FindAsync(id);
            if (brandMaster == null)
            {
                return NotFound();
            }
            return View(brandMaster);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BrandMaster brandMaster)
        {
            if (id != brandMaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    brandMaster.ModifiedBy = UserId;
                    brandMaster.ModifiedDate = DateTime.Now;
                    _context.Update(brandMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandMasterExists(brandMaster.Id))
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
            return View(brandMaster);
        }

        // GET: Brand/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandMaster = await _context.BrandMaster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brandMaster == null)
            {
                return NotFound();
            }

            return View(brandMaster);
        }

        // POST: Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brandMaster = await _context.BrandMaster.FindAsync(id);
            brandMaster.ModifiedBy = UserId;
            brandMaster.ModifiedDate = DateTime.Now;
            brandMaster.IsActive = false;
            _context.BrandMaster.Update(brandMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandMasterExists(int id)
        {
            return _context.BrandMaster.Any(e => e.Id == id);
        }
    }
}
