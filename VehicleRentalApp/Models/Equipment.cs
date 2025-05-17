namespace VehicleRentalApp.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; }
        public decimal PricePerDay { get; set; }
        public string? ImageUrl { get; set; }

        public int EquipmentTypeId { get; set; }
        public EquipmentType? EquipmentType { get; set; }
        public int RentalPointId { get; set; }
        public RentalPoint? RentalPoint { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
