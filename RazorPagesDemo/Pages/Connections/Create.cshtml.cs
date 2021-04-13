using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesDemo.Data;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages.Connections
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesDemo.Data.DemoContext _context;

        public CreateModel(RazorPagesDemo.Data.DemoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CarrierID"] = new SelectList(_context.Carrier, "CarrierID", "CarrierID");
        ViewData["RouteID"] = new SelectList(_context.Route, "RouteID", "RouteID");
            return Page();
        }

        [BindProperty]
        public Connection Connection { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Connection.Add(Connection);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
