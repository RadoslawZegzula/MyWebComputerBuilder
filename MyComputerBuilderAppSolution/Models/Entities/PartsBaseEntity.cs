using System.ComponentModel.DataAnnotations;

namespace MyOnlineShop.Models.Entities
{
    public class PartsBaseEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Stock { get; set; }
        public string Manufacturer { get; set; }
    }
}