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

    private bool AccomplishmentExists(int id)
            {
            return (_context.Accomplishments?.Any(e => e.ID == id)).GetValueOrDefault();
            }
    }
}


