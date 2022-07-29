using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace CompletionCafe.Controllers
{
        public class AccomplishmentSortController : Controller
        {
            
        private readonly Context _context;
        public AccomplishmentSortController(Context context)
            {
                _context = context;
            }

    //Sort Function: LINQ query
    //Use a LINQ query to retrieve information from a data structure (such as a list or array) or file
        public async Task<IActionResult> Sort(string sortOrder, Accomplishment accomplishment)
        {
        thisDay();
        // accomplishment.DaysLeft = Convert.ToString(TestDays(accomplishment.Date));

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

    //DateTime Communicates with REGEX to calculate days until/days since
    public int TestDays(string dueDate){

        int day  = Int32.Parse(dueDate.Substring(3,2));
        int month = Int32.Parse(dueDate.Substring(0,2));
        int year = Int32.Parse(dueDate.Substring(6,4));

        DateTime DueDate_DT = new DateTime(year, month, day);
        // String.Format("{0:MM/dd/yyyy}", due_dt);

        return Convert.ToInt32((DueDate_DT - DateTime.Now).TotalDays);

    }

    public ActionResult thisDay()
        {
            var Dt = DateTime.Now;
            string strDt = Dt.ToString("D");
            ViewBag.CurrentTime = strDt;

            return View();
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


