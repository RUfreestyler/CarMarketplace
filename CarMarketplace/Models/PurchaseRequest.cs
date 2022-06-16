using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.Models
{
    public class PurchaseRequest : IMarketplaceModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int YearOfManufactureLowerBound { get; set; }

        [Required]
        public int YearOfManufactureUpperBound { get; set; }

        [Required]
        public int EnginePowerLowerBound { get; set; }

        [Required]
        public int EnginePowerUpperBound { get; set; }

        [Required]
        public int KilometrageLowerBound { get; set; }

        [Required]
        public int KilometrageUpperBound { get; set; }

        [Required]
        public TransmissionType Transmission { get; set; }

        [Required]
        public CarType Type { get; set; }

        [Required]
        public decimal PriceLowerBound { get; set; }

        [Required]
        public decimal PriceUpperBound { get; set; }

        [Required]
        public int OwnerID { get; set; }
    }
}
