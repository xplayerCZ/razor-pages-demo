using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesDemo.Models
{
    public class Route
    {
        public int RouteID { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public int Length { get; set; }
    }
}
