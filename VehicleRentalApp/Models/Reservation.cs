namespace VehicleRentalApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public int EquipmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Equipment? Equipment { get; set; }
    }
}