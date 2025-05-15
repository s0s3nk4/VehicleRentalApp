namespace VehicleRentalApp.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public int RentalPointId { get; set; }
        public required string CustomerName { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public required Equipment Equipment { get; set; }
        public required RentalPoint RentalPoint { get; set; }
    }
}