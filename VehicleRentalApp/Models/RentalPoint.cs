namespace VehicleRentalApp.Models
{
    public class RentalPoint
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}
