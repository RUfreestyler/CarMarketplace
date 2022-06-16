using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.Models
{
    public enum CarType
    {
        [Display(Name = "Новая")]
        New,

        [Display(Name = "С пробегом")]
        Used
    }
}
