using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CompletionCafe.Controllers
{
    public class AccomplishmentController : Controller
    {
        private readonly Context _context;

        public AccomplishmentController(Context context)
        {
            _context = context;
        }

        // GET: Accomplishment
        public async Task<IActionResult> Index()
        {
            thisDay();
                
              return _context.Accomplishments != null ? 
                          View(await _context.Accomplishments.ToListAsync()) :
                          Problem("Entity set 'Context.Accomplishments'  is null.");
        }

        // GET: Accomplishment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accomplishments == null)
            {
                return NotFound();
            }

            var accomplishment = await _context.Accomplishments
                .FirstOrDefaultAsync(m => m.ID == id);
            if (accomplishment == null)
            {
                return NotFound();
            }

            return View(accomplishment);
        }

        // GET: Accomplishment/Create
        public IActionResult Create()
        {
            return View();
        }

        public ActionResult thisDay()
        {
            var Dt = DateTime.Now;
            string strDt = Dt.ToString("f");
            ViewBag.CurrentTime = strDt;

            return View();
        }

        // POST: Accomplishment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Category,Status,Date,Description,Notes")] Accomplishment accomplishment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accomplishment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accomplishment);
        }

        // GET: Accomplishment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accomplishments == null)
            {
                return NotFound();
            }

            var accomplishment = await _context.Accomplishments.FindAsync(id);
            if (accomplishment == null)
            {
                return NotFound();
            }
            return View(accomplishment);
        }

        // POST: Accomplishment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Category,Status,Date,Description,Notes")] Accomplishment accomplishment)
        {
            if (id != accomplishment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accomplishment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccomplishmentExists(accomplishment.ID))
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
            return View(accomplishment);
        }

        // GET: Accomplishment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accomplishments == null)
            {
                return NotFound();
            }

            var accomplishment = await _context.Accomplishments
                .FirstOrDefaultAsync(m => m.ID == id);
            if (accomplishment == null)
            {
                return NotFound();
            }

            return View(accomplishment);
        }

        // POST: Accomplishment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accomplishments == null)
            {
                return Problem("Entity set 'Context.Accomplishments'  is null.");
            }
            var accomplishment = await _context.Accomplishments.FindAsync(id);
            if (accomplishment != null)
            {
                _context.Accomplishments.Remove(accomplishment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccomplishmentExists(int id)
        {
          return (_context.Accomplishments?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
