using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.Models
{
    public class Car : IMarketplaceModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string YearOfManufacture { get; set; }

        [Required]
        public string EnginePower { get; set; }

        [Required]
        public TransmissionType Transmission { get; set; }

        [Required]
        public CarType Type { get; set; }

        public string? Kilometrage { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int OwnerID { get; set; }
        
        public Car()
        {

        }
    }
}