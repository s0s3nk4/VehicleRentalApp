using Microsoft.EntityFrameworkCore;
using VehicleRentalApp.Data;
using VehicleRentalApp.Models;
using VehicleRentalApp.Repositories.Interfaces;

namespace VehicleRentalApp.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly AppDbContext _context;
        public EquipmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Equipment>> GetAllAsync()
        {
            return await _context.Equipments
                .Include(e => e.EquipmentType)
                .ToListAsync();
        }
        public async Task<IEnumerable<EquipmentType>> GetEquipmentTypesAsync()
        {
            return await _context.EquipmentTypes.ToListAsync();
        }
        public async Task<IEnumerable<RentalPoint>> GetRentalPointsAsync()
        {
            return await _context.RentalPoints.ToListAsync();
        }

        public async Task<Equipment?> GetByIdAsync(int id)
        {
            return await _context.Equipments
                .Include(e => e.EquipmentType)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task AddAsync(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Equipment equipment)
        {
            _context.Equipments.Update(equipment);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var equipment = await GetByIdAsync(id);
            if (equipment != null)
            {
                _context.Equipments.Remove(equipment);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ExistAsync(int id)
        {
            return await _context.Equipments.AnyAsync(e => e.Id == id);
        }
    }
}
