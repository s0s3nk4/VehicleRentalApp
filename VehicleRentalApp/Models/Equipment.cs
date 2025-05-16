namespace VehicleRentalApp.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public required string Brand { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public int Year { get; set; }
        public required string Description { get; set; }
        public decimal PricePerDay { get; set; }
        public required string ImageUrl { get; set; }

        public int EquipmentTypeId { get; set; }
        public EquipmentType? EquipmentType { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
    }
}
