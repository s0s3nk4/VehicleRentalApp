﻿namespace VehicleRentalApp.Models
{
    public class EquipmentType
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
    }
}
