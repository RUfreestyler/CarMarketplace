using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string YearOfManufacture { get; set; }
        public string EnginePower { get; set; }
        public string Transmission { get; set; }
        public string TechnicalState { get; set; }
        public decimal Price { get; set; }
        public int OwnerID { get; set; }
        
        public Car()
        {
            Make = string.Empty;
            Model = string.Empty;
            YearOfManufacture = string.Empty;
            EnginePower = string.Empty;
            Transmission = string.Empty;
            TechnicalState = string.Empty;
        }
    }
}