using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesDemo.Data;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages.Connections
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDemo.Data.DemoContext _context;

        public EditModel(RazorPagesDemo.Data.DemoContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["CarrierID"] = new SelectList(_context.Carrier, "CarrierID", "CarrierID");
           ViewData["RouteID"] = new SelectList(_context.Route, "RouteID", "RouteID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Connection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConnectionExists(Connection.ConnectionID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ConnectionExists(int id)
        {
            return _context.Connection.Any(e => e.ConnectionID == id);
        }
    }
}
