using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public float Price { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime? ExpiryDate { get; set; }
        public Shop Shop { get; set; }
    }
}
