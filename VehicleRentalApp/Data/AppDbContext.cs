using Microsoft.EntityFrameworkCore;
using VehicleRentalApp.Models;

namespace VehicleRentalApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<RentalPoint> RentalPoints { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.EquipmentType)
                .WithMany(et => et.Equipments)
                .HasForeignKey(e => e.EquipmentTypeId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Equipment)
                .WithMany(e => e.Reservations)
                .HasForeignKey(r => r.EquipmentId);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Equipment)
                .WithMany(e => e.Rentals)
                .HasForeignKey(r => r.EquipmentId);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.RentalPoint)
                .WithMany(rp => rp.Rentals)
                .HasForeignKey(r => r.RentalPointId);
        }
    }
}
