using System.ComponentModel.DataAnnotations;

namespace VehicleRentalApp.ViewModels
{
    public class RentalPointViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa punktu")]
        public string? Name { get; set; }
        [Display(Name = "Adres")]
        public string? Address { get; set; }
        [Display(Name = "Liczba wypożyczeń")]
        public int RentalCount { get; set; }
    }
}
