namespace VehicleRentalApp.ViewModels
{
    public class EquipmentItemViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal PricePerDay { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
