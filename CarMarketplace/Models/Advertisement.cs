using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.Models
{
    public class Advertisement
    {
        public int ID { get; set; }
        public string Caption { get; set; }
        public string? Description { get; set; }
        public int OwnerID { get; set; }
        public int ProductID { get; set; }

        [DataType(DataType.Date)]
        public DateTime InsertationDate { get; set; }

        public Advertisement()
        {
            Caption = string.Empty;
        }
    }
}