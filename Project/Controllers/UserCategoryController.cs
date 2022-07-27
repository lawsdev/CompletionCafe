using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CompletionCafe.Controllers
{  
    public class UserCategoryController : Controller
    {
        private readonly Context _context;

        public UserCategoryController(Context context)
        {
            _context = context;
        }
    // GET UserCategory
            public async Task<IActionResult> CategoryIndex()
            {
                return _context.UserCategorys != null ? 
                            View(await _context.UserCategorys.ToListAsync()) :
                            Problem("Entity set 'Context.UserCategorys'  is null.");
            }

            // Create List of Categories in UserCategory class
            public async Task<IActionResult> CreateCategory(UserCategory usercategory)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(usercategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(CategoryIndex));
                }
                return View(usercategory);
            }
    }
}