using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesDemo.Data;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages.Connections
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesDemo.Data.DemoContext _context;

        public DetailsModel(RazorPagesDemo.Data.DemoContext context)
        {
            _context = context;
        }

        public Connection Connection { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Connection = await _context.Connection
                .Include(c => c.Carrier)
                .Include(c => c.Route).FirstOrDefaultAsync(m => m.ConnectionID == id);

            if (Connection == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
