using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesDemo.Data;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages.Carriers
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesDemo.Data.DemoContext _context;

        public IndexModel(RazorPagesDemo.Data.DemoContext context)
        {
            _context = context;
        }

        public IList<Carrier> Carrier { get;set; }

        public async Task OnGetAsync()
        {
            Carrier = await _context.Carrier.ToListAsync();
        }
    }
}
