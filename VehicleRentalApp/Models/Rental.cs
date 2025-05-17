namespace VehicleRentalApp.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public int RentalPointId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Equipment? Equipment { get; set; }
        public RentalPoint? RentalPoint { get; set; }
    }
}