namespace VehicleRentalApp.Models
{
    public class RentalPoint
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }

        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
