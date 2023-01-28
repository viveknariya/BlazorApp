using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<Product> Product { get; set; }
    }
}
