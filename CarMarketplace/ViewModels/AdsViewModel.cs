using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.ViewModels
{
    public class AdsViewModel
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime InsertationDate { get; set; }
        public int ProductID { get; set; }
        public int OwnerID { get; set; }
    }
}
