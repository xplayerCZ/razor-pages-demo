using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Data
{
    public class DemoContext : IdentityDbContext
    {
        public DemoContext (DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesDemo.Models.Carrier> Carrier { get; set; }
        public DbSet<RazorPagesDemo.Models.Connection> Connection { get; set; }
        public DbSet<RazorPagesDemo.Models.Route> Route { get; set; }
    }
}
