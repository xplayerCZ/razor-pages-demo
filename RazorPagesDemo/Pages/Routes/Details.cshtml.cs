using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesDemo.Data;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages.Routes
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesDemo.Data.DemoContext _context;

        public DetailsModel(RazorPagesDemo.Data.DemoContext context)
        {
            _context = context;
        }

        public Route Route { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Route = await _context.Route.FirstOrDefaultAsync(m => m.RouteID == id);

            if (Route == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
