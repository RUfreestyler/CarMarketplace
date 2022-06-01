using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.Models
{
    public class Owner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }

        public Owner()
        {
            Name = string.Empty;
            City = string.Empty;
            PhoneNumber = string.Empty;
        }
    }
}