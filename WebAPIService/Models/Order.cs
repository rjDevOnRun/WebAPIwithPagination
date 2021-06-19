using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIService.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
    }
}
