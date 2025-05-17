using System.ComponentModel.DataAnnotations;

namespace VehicleRentalApp.ViewModels
{
    public class EquipmentDetailViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Marka jest wymagana")]
        public string? Brand { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string? Name { get; set; }
        public string? Type { get; set; }
        [Range(2000, 2025, ErrorMessage = "Rok musi być w zakresie 2000 - 2025")]
        public int Year { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Cena jest wymagana")]
        public decimal PricePerDay { get; set; }
        [Url(ErrorMessage = "Zdjęcie jest wymagane")]
        public string? ImageUrl { get; set; }
        [Required(ErrorMessage = "Wybierz poprawny typ")]
        public int EquipmentTypeId { get; set; }
        public string? EquipmentType { get; set; }
        [Required(ErrorMessage = "Wybierz poprawny punkt")]
        public int RentalPointId { get; set; }
        public string? RentalPoint { get; set; } 
    }
}
