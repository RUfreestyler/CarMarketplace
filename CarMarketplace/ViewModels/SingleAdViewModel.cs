using CarMarketplace.Models;
using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.ViewModels
{
    public class SingleAdViewModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime InsertationDate { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string YearOfManufacture { get; set; }
        public string EnginePower { get; set; }
        public TransmissionType Transmission { get; set; }
        public CarType Type { get; set; }
        public string Kilometrage { get; set; }
        public string Description { get; set; }
    }
}
