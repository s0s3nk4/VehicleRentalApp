namespace VehicleRentalApp.Models
{
    public class RentalPoint
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }

        public required ICollection<Rental> Rentals { get; set; }
    }
}
