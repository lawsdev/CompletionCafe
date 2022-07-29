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
            // thisDay();

              return _context.Accomplishments != null ? 
                          View(await _context.Accomplishments.ToListAsync()) :
                          Problem("Entity set 'Context.Accomplishments'  is null.");
        }

    //Sort Function: LINQ query
    //Use a LINQ query to retrieve information from a data structure (such as a list or array) or file
        public async Task<IActionResult> Sort(string sortOrder, Accomplishment accomplishment)
        {

        ViewData["CategorySortParm"] = sortOrder == "Category" ? "category_desc" : "Category";
        ViewData["StatusSortParm"] = sortOrder == "Status" ? "status_desc" : "Status";
        // ViewData["DateLeftSortParm"] = sortOrder == "DateLeft" ? "dateleft_desc" : "DateLeft";
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
            case "Status"://bool status incomplete
                accomplishments = accomplishments.OrderBy(s => s.Status);
                break; 
            case "status_desc"://bool status complete
                accomplishments = accomplishments.OrderByDescending(s => s.Status);
                break;
            default:
                accomplishments = accomplishments.OrderBy(s => s.ID);
                break;
        }

        return View(("Index"), await accomplishments.AsNoTracking().ToListAsync());
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

        // RETIRED METHOD TO CALCULATE DAYS LEFT
        // //DateTime Communicates with REGEX to calculate days until/days since
        // public int TestDays(string dueDate){

        //     int day  = Int32.Parse(dueDate.Substring(3,2));
        //     int month = Int32.Parse(dueDate.Substring(0,2));
        //     int year = Int32.Parse(dueDate.Substring(6,4));

        //     DateTime DueDate_DT = new DateTime(year, month, day);
        //     // String.Format("{0:MM/dd/yyyy}", due_dt);

        //     return Convert.ToInt32((DueDate_DT - DateTime.Now).TotalDays);

        // }

        public ActionResult thisDay()
        {
            var Dt = DateTime.Now;
            string strDt = Dt.ToString("d");
            ViewBag.CurrentTime = strDt;

            return View();
        }
        
        // GET: Accomplishment/Create
        public IActionResult Create()
        {
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
