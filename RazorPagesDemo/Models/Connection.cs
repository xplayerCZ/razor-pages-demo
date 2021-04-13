using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesDemo.Models
{
    public class Connection
    {
        public int ConnectionID { get; set; }
        public int CarrierID { get; set; }
        public int RouteID { get; set; }
        public DateTime Start { get; set; }
        public bool CarriesBikes { get; set; }
        public bool IsLowRise { get; set; }

        public Carrier Carrier { get; set; }
        public Route Route { get; set; }
    }
}
