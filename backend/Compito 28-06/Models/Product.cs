using Microsoft.AspNetCore.Http;

namespace DiamaGyms.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? AdditionalImageUrl { get; set; }

        public IFormFile? CoverImageFile { get; set; }
        public IFormFile? AdditionalImageFile { get; set; }
    }
}