using System.ComponentModel.DataAnnotations;

namespace VehicleRentalApp.ViewModels
{
    public class RentalPointViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa punktu")]
        public required string Name { get; set; }
        [Display(Name = "Adres")]
        public required string Address { get; set; }
        [Display(Name = "Liczba wypożyczeń")]
        public int RentalCount { get; set; }
    }
}
