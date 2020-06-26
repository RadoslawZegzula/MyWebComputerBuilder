using System.ComponentModel.DataAnnotations;

namespace MyOnlineShop.Models.ModelsToDisplay
{
    public class DisplayBaseModel 
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public string Manufacturer { get; set; }
    }
}