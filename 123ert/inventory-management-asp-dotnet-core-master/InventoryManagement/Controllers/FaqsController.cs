using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;
using System.Security.Claims;

namespace InventoryManagement.Controllers
{
    public class FaqsController : Controller
    {
        private readonly yournotebookContext _context;
        public long UserId { get { return Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier)); } }
        List<string> faqCategory = new List<string>() { "General", "Registration", "Payment", "Delivery Related", "Order Related", "Return & Refund" };
        public FaqsController(yournotebookContext context)
        {
            _context = context;
        }

        // GET: Faqs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Faq.ToListAsync());
        }

        // GET: Faqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _context.Faq
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faq == null)
            {
                return NotFound();
            }

            return View(faq);
        }

        // GET: Faqs/Create
        public IActionResult Create()
        {
            var faqTypes = faqCategory
                .Select(x => new SelectListItem() { Value = x, Text = x });
            ViewBag.FaqTypes = faqTypes;
            return View();
        }

        // POST: Faqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Question,Answer,IsActive")] Faq faq)
        {
            if (ModelState.IsValid)
            {
                faq.CreatedBy = UserId;
                faq.CreatedDate = DateTime.Now;
                _context.Add(faq);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var faqTypes = faqCategory
                .Select(x => new SelectListItem() { Value = x, Text = x });
            ViewBag.FaqTypes = faqTypes;
            return View(faq);
        }

        // GET: Faqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _context.Faq.FindAsync(id);
            if (faq == null)
            {
                return NotFound();
            }
            var faqTypes = faqCategory
                .Select(x => new SelectListItem() { Value = x, Text = x });
            ViewBag.FaqTypes = faqTypes;
            return View(faq);
        }

        // POST: Faqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Question,Answer,IsActive,CreatedBy,CreatedDate")] Faq faq)
        {
            if (id != faq.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faq);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaqExists(faq.Id))
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
            var faqTypes = faqCategory
                .Select(x => new SelectListItem() { Value = x, Text = x });
            ViewBag.FaqTypes = faqTypes;
            return View(faq);
        }

        // GET: Faqs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faq = await _context.Faq
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faq == null)
            {
                return NotFound();
            }

            return View(faq);
        }

        // POST: Faqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faq = await _context.Faq.FindAsync(id);
            _context.Faq.Remove(faq);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaqExists(int id)
        {
            return _context.Faq.Any(e => e.Id == id);
        }
    }
}
