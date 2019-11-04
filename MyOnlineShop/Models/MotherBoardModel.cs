using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyOnlineShop.Models
{
    public class MotherBoardModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }

        public string Manufacturer { get; set; }
        public string ChipModel { get; set; }
        public string Socket { get; set; }
        public int SoundCardCanals { get; set; }
        public int NetworkCard { get; set; }
        public string RearPanelConnectors { get; set; }
        public string MultiGpu { get; set; }
        public int RamSlots { get; set; }
        public int Frequency { get; set; }
        public int Wattage { get; set; }


    }
}