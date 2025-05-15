namespace VehicleRentalApp.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public required string Type { get; set; }
        public int Year { get; set; }
        public required string Description { get; set; }
        public decimal PricePerDay { get; set; }
        public required string ImageUrl { get; set; }
    }
}
