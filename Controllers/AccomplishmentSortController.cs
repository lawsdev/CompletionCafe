using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CompletionCafe.Controllers;
    public class AccomplishmentSortController : Controller
    {
        private readonly Context _context;
        public AccomplishmentSortController(Context context)
            {
                _context = context;
            }

//Sort Function: LINQ query
    public async Task<IActionResult> Sort(string sortOrder)
{
    ViewData["CategorySortParm"] = sortOrder == "Category" ? "category_desc" : "Category";
    ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
    ViewData["StatusSortParm"] = sortOrder == "Status" ? "Unfinished" : "Status";
    var accomplishments = from s in _context.Accomplishments
                   select s;
    switch (sortOrder)
    {
        case "Category"://category ascending
            accomplishments = accomplishments.OrderBy(s => s.Category);
            break;
        case "category_desc"://category descending
            accomplishments = accomplishments.OrderByDescending(s => s.Category);
            break;
        case "Complete"://bool status complete
            accomplishments = accomplishments.OrderByDescending(s => s.Status);
            break;
        case "Unfinished"://bool status incomplete
            accomplishments = accomplishments.OrderBy(s => s.Status);
            break;
        case "Date"://date ascending
            accomplishments = accomplishments.OrderBy(s => s.Date);
            break;
        case "date_desc"://date descending
            accomplishments = accomplishments.OrderByDescending(s => s.Date);
            break;
        default:
            accomplishments = accomplishments.OrderBy(s => s.ID);
            break;
    }
    return View(await accomplishments.AsNoTracking().ToListAsync());
}

        // public async Task<IActionResult> Sort(int? id)
        // {
        //     if (id == null || _context.Accomplishments == null)
        //     {
        //         return NotFound();
        //     }

        //     var accomplishment = await _context.Accomplishments
        //         .FirstOrDefaultAsync(m => m.ID == id);
        //     if (accomplishment == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(accomplishment);
        // }

        

       

        // // POST: Accomplishment/Create
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("ID,Category,Status,Date,Description,Notes")] Accomplishment accomplishment)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(accomplishment);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(accomplishment);
        // }

        // // GET: Accomplishment/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null || _context.Accomplishments == null)
        //     {
        //         return NotFound();
        //     }

        //     var accomplishment = await _context.Accomplishments.FindAsync(id);
        //     if (accomplishment == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(accomplishment);
        // }

        // // POST: Accomplishment/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to.
        // // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("ID,Category,Status,Date,Description,Notes")] Accomplishment accomplishment)
        // {
        //     if (id != accomplishment.ID)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(accomplishment);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!AccomplishmentExists(accomplishment.ID))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(accomplishment);
        // }

        // // GET: Accomplishment/Delete/5
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null || _context.Accomplishments == null)
        //     {
        //         return NotFound();
        //     }

        //     var accomplishment = await _context.Accomplishments
        //         .FirstOrDefaultAsync(m => m.ID == id);
        //     if (accomplishment == null)
        //     {
        //         return NotFound();
        //     }

        //     return View(accomplishment);
        // }

        // // POST: Accomplishment/Delete/5
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     if (_context.Accomplishments == null)
        //     {
        //         return Problem("Entity set 'Context.Accomplishments'  is null.");
        //     }
        //     var accomplishment = await _context.Accomplishments.FindAsync(id);
        //     if (accomplishment != null)
        //     {
        //         _context.Accomplishments.Remove(accomplishment);
        //     }
            
        //     await _context.SaveChangesAsync();
        //     return RedirectToAction(nameof(Index));
        // }

        private bool AccomplishmentExists(int id)
        {
          return (_context.Accomplishments?.Any(e => e.ID == id)).GetValueOrDefault();
        }
        
    }

