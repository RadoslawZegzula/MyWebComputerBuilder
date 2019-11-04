using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyOnlineShop.Models
{
    public class Cpu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }

        public int Frequency { get; set; }
        public int Cores { get; set; }
        public string Socket { get; set; }
        public int Wattage { get; set; }

    }
}