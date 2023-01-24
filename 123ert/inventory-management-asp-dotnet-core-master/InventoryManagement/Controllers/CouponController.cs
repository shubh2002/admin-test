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
    public class CouponController : Controller
    {
        private readonly yournotebookContext _context;
        public long UserId { get { return Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier)); } }
        public CouponController(yournotebookContext context)
        {
            _context = context;
        }

        // GET: Coupon
        public async Task<IActionResult> Index()
        {
            try
            {
                var abc = await _context.CouponMaster.OrderByDescending(x => x.Id).ToListAsync();
            }catch(Exception ex)
            {

            }
            return View(await _context.CouponMaster.OrderByDescending(x=>x.Id).ToListAsync());
        }

        // GET: Coupon/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var couponMaster = await _context.CouponMaster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (couponMaster == null)
            {
                return NotFound();
            }

            return View(couponMaster);
        }

        // GET: Coupon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coupon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShortDescription,LongDescription,Code,Discount,FlatDiscount,MaxDiscount,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,StartDate,EndDate,ApplicableCount,CouponCategoryId,MinimumCartAmount,IsPrivate,Priority,Pin")] CouponMaster couponMaster)
        {
            if (ModelState.IsValid)
            {
                couponMaster.CreatedBy = UserId;
                couponMaster.CreatedDate = DateTime.Now;
                _context.Add(couponMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(couponMaster);
        }

        // GET: Coupon/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var couponMaster = await _context.CouponMaster.FindAsync(id);
            if (couponMaster == null)
            {
                return NotFound();
            }
            return View(couponMaster);
        }

        // POST: Coupon/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ShortDescription,LongDescription,Code,Discount,FlatDiscount,MaxDiscount,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,StartDate,EndDate,ApplicableCount,CouponCategoryId,MinimumCartAmount,IsPrivate,Priority,Pin")] CouponMaster couponMaster)
        {
            if (id != couponMaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    couponMaster.ModifiedBy = UserId;
                    couponMaster.ModifiedDate = DateTime.Now;
                    _context.Update(couponMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CouponMasterExists(couponMaster.Id))
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
            return View(couponMaster);
        }

        // GET: Coupon/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var couponMaster = await _context.CouponMaster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (couponMaster == null)
            {
                return NotFound();
            }

            return View(couponMaster);
        }

        // POST: Coupon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var couponMaster = await _context.CouponMaster.FindAsync(id);
            couponMaster.IsActive = false;
            _context.CouponMaster.Update(couponMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CouponMasterExists(long id)
        {
            return _context.CouponMaster.Any(e => e.Id == id);
        }
    }
}
