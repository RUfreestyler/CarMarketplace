using System.ComponentModel.DataAnnotations;

namespace CarMarketplace.Models
{
    public enum TransmissionType
    {
        [Display(Name = "Автомат")]
        Automatic,

        [Display(Name = "Механика")]
        Manual,

        [Display(Name = "Робот")]
        AutomatedManual,

        [Display(Name = "Вариатор")]
        ContinuouslyVariable
    }
}
