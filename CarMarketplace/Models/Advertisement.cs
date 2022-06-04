using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.Models
{
    public class Advertisement : IMarketplaceModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public int OwnerID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime InsertationDate { get; set; }

        public Advertisement()
        {

        }
    }
}