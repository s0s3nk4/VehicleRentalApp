namespace VehicleRentalApp.ViewModels
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public int EquipmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
