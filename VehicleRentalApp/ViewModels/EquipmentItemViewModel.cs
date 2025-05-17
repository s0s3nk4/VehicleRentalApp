namespace VehicleRentalApp.ViewModels
{
    public class EquipmentItemViewModel
    {
        public int Id { get; set; }
        public string? Brand { get; set; } 
        public string? Name { get; set; } 
        public string? Type { get; set; } 
        public decimal PricePerDay { get; set; }
        public string? ImageUrl { get; set; } 
        public string? EquipmentType { get; set; } 
        public string? RentalPoint { get; set; } 
    }
}
