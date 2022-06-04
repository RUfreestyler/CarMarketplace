using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.Models
{
    public class Owner : IMarketplaceModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        [Required]
        public int PasswordHash { get; set; }

        public Owner()
        {
            
        }
    }
}